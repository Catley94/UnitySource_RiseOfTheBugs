using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item_OnHit : MonoBehaviour
{
    
    private ObjectPool<GameObject> objectPool;

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
        Debug.Log(other);
    }
    
    public void SetObjectPool(ObjectPool<GameObject> objectPool)
    {
        this.objectPool = objectPool;
    }
    
}
