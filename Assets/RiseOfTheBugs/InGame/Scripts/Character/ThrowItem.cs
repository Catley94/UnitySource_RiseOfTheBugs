using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int rightForce = 1000;
    [SerializeField] private int upwardForce = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject item = Instantiate(itemPrefab, transform.position, transform.rotation);
            //TODO: Set Item Config
            // item.GetComponent<Item>().SetItem();
         
            // Calculate the forward and upward directions for the arc
            Vector3 rightDirection = Vector3.right; // You can modify this if you want to change the forward direction
            Vector3 upwardDirection = (Vector3.up + Vector3.right).normalized; // The arc direction (45-degree angle)

            // Add forces to the Rigidbody in both directions to create an arc
            item.GetComponent<Rigidbody2D>().AddForce(rightDirection * rightForce); // Adjust the force magnitude as needed
            item.GetComponent<Rigidbody2D>().AddForce(upwardDirection * upwardForce);
            
            //Set Object Pool
            // item.GetComponent<OnHit>().SetObjectPool();
            
        }
    }
}