using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Score score;
    


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreActivate()
    {
        score.AddScore();
       
        Destroy(gameObject);
    }




}
