using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public SplineCount spline;
    
    private Transform thisTransform;

    public float turnSpeed = 1.0f;

    private Vector3 prevPosition;

    public AudioSource wave;
    public AudioSource slide;

    // Declare movement Speed
    public float moveSpeed = 12.0f;

    // State
    public bool moveOn = true;


    public GameObject pointer;


    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;

        prevPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position = spline.WhereOnSpline(thisTransform.position);



        // Calculate position change between frames
        Vector3 deltaPosition = transform.position - prevPosition;



        if (deltaPosition != Vector3.zero)
        {
            // Same effect as rotating with quaternions, but simpler to read
            //transform.forward = deltaPosition;

            // Set up rotation target
            Quaternion rotTarget = Quaternion.LookRotation(transform.position - prevPosition);


            // Set the rotation in motion
            thisTransform.rotation = Quaternion.Lerp(thisTransform.rotation, rotTarget, turnSpeed * Time.deltaTime);


        }
        // Recording current position as previous position for next frame
        prevPosition = transform.position;


        // Move player forwards if state is on move state
        if (moveOn)
        {

            // Smooth acceleration
            if (moveSpeed < 12.0)
            {
                moveSpeed += 0.1f;
            }

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Fix move speed
            if (moveSpeed > 20)
            {
                moveSpeed = 20f;
            }

        }



    }

    public void SetMoveOn()
    {
        moveOn = true;
    }

    public void SetMoveOff()
    {
        moveOn = false;
        wave.Stop();
        slide.Stop();

        pointer.SetActive(true);
    }

}

