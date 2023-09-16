using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_OnHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO: Reduce health of Player
        }

        if (other.gameObject.CompareTag("BugFixItem"))
        {
            //TODO: Reduce health of Bug or Return to pool
        }
    }
}
