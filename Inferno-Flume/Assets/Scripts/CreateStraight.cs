using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStraight : MonoBehaviour
{

    public GameObject straight;

    private bool createState = true;

    private Transform player;
    private Transform thisTransform;

    private float triggerDistance = 30000.0f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        thisTransform = transform;
    }



    // Update is called once per frame
    void Update()
    {


        float sqrDistance = (thisTransform.position - player.position).sqrMagnitude;

        if (createState && sqrDistance <= triggerDistance)
        {
            createState = false;
            Instantiate(straight, transform.position, transform.rotation);
        }
    }
}
