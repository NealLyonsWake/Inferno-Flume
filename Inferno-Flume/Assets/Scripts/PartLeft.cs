using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartLeft : MonoBehaviour
{
    public bool Go = false;
    private float speed = 1.0f;

    public TrackMovement player;
    public VRRotate playerCtrl;

    
 

    // Update is called once per frame
    void Update()
    {
        if (Go)
        {
            if(speed < 50)
            {
                speed += 0.1f;
            }
                                    
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
        if(transform.position.x > 50)
        {
            Destroy(gameObject);
            player.SetMoveOn();
            playerCtrl.RotateOn();
        }
        if(transform.position.y > 50)
        {
            Destroy(gameObject);
        }
        if(transform.position.z > 50)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -50)
        {
            Destroy(gameObject);
        }



    }

    public void SetGo()
    {
        Go = true;
    }


}
