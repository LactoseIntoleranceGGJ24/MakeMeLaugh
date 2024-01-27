using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour

{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Type type1 = otherObj.GetType();
        
        if (otherObj.tag=="Player")
        {
           Debug.Log("Hi PlAYER" + otherObj);
            AddToPlayerInventory();
        }
        //Debug.Log("Triggered with: " + otherObj);
        //Debug.Log("Hi PlAYER" + type1);
        
    }

    void AddToPlayerInventory()
    {
        
    }

}
