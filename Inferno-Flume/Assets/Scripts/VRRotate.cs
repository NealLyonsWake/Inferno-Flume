using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRotate : MonoBehaviour
{
    // Set speed of player head tilt
    public float moveSpeed = 5.0f;

    // Set player head tilt min and max angles  
    private float vrRoll;
    private float minRollLimitL = 20;
    private float maxRollLimitL = 90;
    private float minRollLimitR = 340;
    private float maxRollLimitR = 270;

    public bool rotateOn = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the rotation value of the main camera and declare in vrRoll variable
        vrRoll = Camera.main.transform.localEulerAngles.z;

        if (rotateOn)
        {
            // Rotate code - left/right with VR head tilt left of right:
            if (vrRoll >= minRollLimitL && vrRoll <= maxRollLimitL)
            {
                transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime); // Rotate left
            }

            if (vrRoll <= minRollLimitR && vrRoll >= maxRollLimitR)
            {
                transform.Rotate(Vector3.back * moveSpeed * Time.deltaTime); // Rotate right
            }
        }
    }

    public void RotateOn()
    {
        rotateOn = true;
    }

    public void RotateOff()
    {
        rotateOn = false;
    }

}
