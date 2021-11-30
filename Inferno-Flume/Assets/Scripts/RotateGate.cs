using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGate : MonoBehaviour
{

    private Transform thisTransform;
    public float rotationSpeed = 1.0f;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            thisTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

    }



    public void GameOver()
    {
        gameOver = true;
    }


}
