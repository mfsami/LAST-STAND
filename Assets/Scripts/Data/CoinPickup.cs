using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp) return; // Prevent duplicate triggers
        if (collision.CompareTag("Player"))
        {
            pickedUp = true;

            PlayerData playerData = collision.GetComponent<PlayerData>();
            if (playerData != null)
            {
                playerData.AddCoin(coinValue);
                playerData.totalCoinsCollected += coinValue;
            }

            Destroy(gameObject);
        }
    }
}
