using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBend : MonoBehaviour
{

    public GameObject[] bends;
    private int bendIndex;

    private bool createState = true;

    private Transform player;
    private Transform thisTransform;

    private float triggerDistance = 30000.0f;

    // Start is called before the first frame update
    void Start()
    {
        bendIndex = Random.Range(0,4);
        player = GameObject.Find("Player").transform;
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        float sqrDistance = (thisTransform.position - player.position).sqrMagnitude;
       
            if (createState && sqrDistance <= triggerDistance) // For now event is triggered by pressing space
        {
            createState = false;
            Instantiate(bends[bendIndex], transform.position, transform.rotation);
        }
    }
}
