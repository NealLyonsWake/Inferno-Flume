using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textScore;
    public int score = 0;
    public AudioSource collected;

    public VRRotate playerCtrl;
    public TrackMovement player;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        textScore.text = score.ToString() + "/30";

        if(score >= 30)
        {
            playerCtrl.RotateOff();
            player.SetMoveOff();

            menu.SetActive(true);

            RotateGate end = GameObject.Find("Barrier").GetComponent<RotateGate>();
            end.GameOver();
                                    
        }


    }

    public void AddScore()
    {
        score += 1;
        collected.Play();

    }


}
