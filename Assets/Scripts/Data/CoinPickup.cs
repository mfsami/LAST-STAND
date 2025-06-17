using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1; // Set value in the Inspector

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData playerData = collision.GetComponent<PlayerData>();

            // Does the object i just collided with have a game data componenet
            if (playerData != null)
            {
                playerData.AddCoin(coinValue);
                playerData.totalCoinsCollected += coinValue;

            }

            Destroy(gameObject);
        }
    }
}

