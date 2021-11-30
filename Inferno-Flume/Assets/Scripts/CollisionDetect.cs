using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetect : MonoBehaviour
{
    public VRRotate playerCtrl;
    public TrackMovement player;
    
  
    public GameObject menu;

    public AudioSource music;

    bool playOver = false;
  


    private void OnTriggerEnter(Collider other)
    {
        CollisionDetect detect = other.GetComponent<CollisionDetect>();
        if(detect != null)
        {
            playerCtrl.RotateOff();
            player.SetMoveOff();

            menu.SetActive(true);
            Destroy(other.gameObject);

            music.Stop();

            playOver = true;
          
        }

        Collectable collect = other.GetComponent<Collectable>();
        if(collect != null && !playOver)
        {
            collect.ScoreActivate();
        }

       


    }



}
