using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{

    public bool playerInRange = false;
    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            playerInRange = true;
            Debug.Log("PRESS E TO OPEN SHOP");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("OUTSIDE RANGE");
        }
    }
}
