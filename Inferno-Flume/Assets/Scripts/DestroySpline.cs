using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpline : MonoBehaviour
{
    private Transform player;
    private bool proximityTrigger = false;
    private Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float sqrDistance = (thisTransform.position - player.position).sqrMagnitude;
        if (sqrDistance <= 5.0f) 
        {
            proximityTrigger = true;
        } 

        if (proximityTrigger && sqrDistance >= 800)
        {
            Destroy(this.gameObject);
        }




    }
}
