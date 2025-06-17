using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{

    public bool playerInRange = false;
    public Animator interact;

    public GameObject shopMenu;
    private InteractPopUp popUp;

    private void Start()
    {
        popUp = GetComponentInChildren<InteractPopUp>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            shopMenu.SetActive(true);
            playerInRange = true;
            popUp.Show();

            // Register this merchant with the shop controller
            ShopMenuController shop = FindObjectOfType<ShopMenuController>();
            shop.merchant = this;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            popUp.Hide();
        }
    }
}
