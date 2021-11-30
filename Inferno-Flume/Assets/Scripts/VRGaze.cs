using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGaze : MonoBehaviour
{
    //Objects
    public Image imgGaze;
    public AudioSource music;
    public AudioSource wave;
    public AudioSource slide;
    public Text score;
    public Image icon;
       
    
    //Status 
    bool beginStatus;
    bool startStatus;
    bool exitStatus;
    bool howStatus;
    bool next1Status;
    bool next2Status;
    bool next3Status;
    bool restartStatus;
    bool notReadStatus;
    bool readStatus;

    
    // Time
    float gvrTimer;
    public float totalTime = 1;

    float logoTime = 0.0f;
    float logoTotalTime = 3.0f;

    // Menus
    public GameObject studioLogo;
    public GameObject title;
    public GameObject mainMenu;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject safety;

    // Bedroom stuff attached to scrip of PartLeft
    public PartLeft floor;
    public PartLeft ceiling;
    public PartLeft wall1;
    public PartLeft wall2;
    public PartLeft wall3;
    public PartLeft wall4;
    public PartLeft drawer;
    public PartLeft tv;
    public PartLeft rug;


    // GVR pointer
    public GameObject reticle;


    //Titel screed start up switch
    bool started = false;


    // Update is called once per frame
    void Update()
    {
        // Show Logo
        if(logoTime < logoTotalTime && !started)
        {
            logoTime += Time.deltaTime;
        }

        if(logoTime >= logoTotalTime && !started)
        {
            studioLogo.SetActive(false);
            title.SetActive(true);
            started = true;
        }



        // Begin
        if (beginStatus)
        {
            gvrTimer += Time.deltaTime*2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if(beginStatus && imgGaze.fillAmount == 1)
        {
            beginStatus = false;
            title.SetActive(false);
            safety.SetActive(true);
            gvrTimer = 0;
            imgGaze.fillAmount = 0;
            
        }

        // Start Game
        if (startStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (startStatus && imgGaze.fillAmount == 1)
        {
            // tidy values
            startStatus = false;
            gvrTimer = 0;
            imgGaze.fillAmount = 0;


            // activate PartLeft script on bedroom items
            floor.SetGo();
            ceiling.SetGo();
            wall1.SetGo();
            wall2.SetGo();
            wall3.SetGo();
            wall4.SetGo();
            drawer.SetGo();
            tv.SetGo();
            rug.SetGo();

            
            reticle.SetActive(false);
            score.enabled = true;
            icon.enabled = true;

            music.Play();
            wave.Play();
            slide.Play();
        }

        // Exit
        if (exitStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (exitStatus && imgGaze.fillAmount == 1)
        {
            exitStatus = false;
            gvrTimer = 0;
            imgGaze.fillAmount = 0;
            Application.Quit();

        }

        // How to Play
        if (howStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (howStatus && imgGaze.fillAmount == 1)
        {
            howStatus = false;


            mainMenu.SetActive(false);
            tutorial1.SetActive(true);


            gvrTimer = 0;
            imgGaze.fillAmount = 0;

        }


        // Tutorial 1
        if (next1Status)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (next1Status && imgGaze.fillAmount == 1)
        {
            next1Status = false;


            tutorial1.SetActive(false);
            tutorial2.SetActive(true);


            gvrTimer = 0;
            imgGaze.fillAmount = 0;

        }


        // Tutorial 2
        if (next2Status)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (next2Status && imgGaze.fillAmount == 1)
        {
            next2Status = false;


            tutorial2.SetActive(false);
            tutorial3.SetActive(true);


            gvrTimer = 0;
            imgGaze.fillAmount = 0;

        }


        // Tutorial 3
        if (next3Status)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (next3Status && imgGaze.fillAmount == 1)
        {
            next3Status = false;


            tutorial3.SetActive(false);
            mainMenu.SetActive(true);


            gvrTimer = 0;
            imgGaze.fillAmount = 0;

        }

        // restart
        if (restartStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (restartStatus && imgGaze.fillAmount == 1)
        {
            restartStatus = false;
            gvrTimer = 0;
            imgGaze.fillAmount = 0;
            SceneManager.LoadScene("Game");

        }

        // not read and quit
        if (notReadStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (notReadStatus && imgGaze.fillAmount == 1)
        {
            notReadStatus = false;
            gvrTimer = 0;
            imgGaze.fillAmount = 0;
            Application.Quit(); 

        }


        // read and continue
        if (readStatus)
        {
            gvrTimer += Time.deltaTime * 2;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if (readStatus && imgGaze.fillAmount == 1)
        {
            readStatus = false;
            gvrTimer = 0;
            imgGaze.fillAmount = 0;

            mainMenu.SetActive(true);
            safety.SetActive(false);

        }





    }



    //Begin
    public void BeginOn()
    {
        beginStatus = true;
    }

    public void BeginOff()
    {
        beginStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Start Game
    public void StartGameOn()
    {
        startStatus = true;
    }

    public void StartGameOff()
    {
        startStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Not read safety info
    public void NotReadOn()
    {
        notReadStatus = true;
    }

    public void NotReadOff()
    {
        notReadStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }

    //Read safety info
    public void ReadOn()
    {
        readStatus = true;
    }

    public void ReadOff()
    {
        readStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }




    //Exit
    public void ExitOn()
    {
        exitStatus = true;
    }

    public void ExitOff()
    {
        exitStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //How to play
    public void HowToOn()
    {
        howStatus = true;
    }

    public void HotoOff()
    {
        howStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Next 1
    public void Next1On()
    {
        next1Status = true;
    }

    public void Next1Off()
    {
        next1Status = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Next 2
    public void Next2On()
    {
        next2Status = true;
    }

    public void Next2Off()
    {
        next2Status = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Next 3
    public void Next3On()
    {
        next3Status = true;
    }

    public void Next3Off()
    {
        next3Status = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }


    //Restart
    public void RestartOn()
    {
        restartStatus = true;
    }

    public void RestartOff()
    {
        restartStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }



}
