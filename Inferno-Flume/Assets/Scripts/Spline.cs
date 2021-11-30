using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{

   
    // Declare the 2 transforms that need to interact with each other
    public GameObject player;
    private Transform spline;
    
   
    private GameObject splineManager;
    


    // Start is called before the first frame update
    void Start()
    {
        // Get the specifc child spline of the object
        spline = transform.GetChild(0).transform;

        // Get player object
        player = GameObject.Find("Player");
            
               
        splineManager = GameObject.Find("Spline Manager");
        spline.transform.parent = splineManager.transform;
        splineManager.GetComponent<SplineCount>().NextSpline();
    


    }


}





