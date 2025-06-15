using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class ShopMenuController : MonoBehaviour
{
    public Animator sign1Animator;
    public Animator sign2Animator;
    public Animator sign3Animator;

    private int money;

    private bool shopIsOpen = false;

    public Merchant merchant;

    public GunController weapon;

    public GameObject buttons;


    public PlayerData playerData;

    // Weapons
    public SpriteRenderer weaponSpriteRenderer;
    public Sprite akSprite;
    public Sprite shotgunSprite;
    public Sprite sniperSprite;

    //


    // Shop prices

    public int akPrice = 20;
    public int shotgunPrice = 50;
    public int sniperPrice = 100;


    //public GameObject shopMenuParent;


    void Update()
    {

        if (merchant == null)
        {
            Debug.LogWarning("Merchant is NULL!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && merchant.playerInRange)
        {
            // Shop is closed and player in range of merchant
            if (!shopIsOpen)
            {
                //shopMenuParent.SetActive(true);
                OpenShop();
            }
            
            else 
            {
                //shopMenuParent.SetActive(false);
                CloseShop();
            }
        }

        // Shop is open, Player outside of range
        if (shopIsOpen &&  merchant.playerInRange == false)
        {
            CloseShop();
        }

    }

    private void OpenShop()
    {
        
        sign1Animator.SetTrigger("Drop");
        sign2Animator.SetTrigger("Drop");
        sign3Animator.SetTrigger("Drop");
        shopIsOpen = true;

        // Disable player input
        weapon.enabled = false;
        buttons.SetActive(true);
    }

    private void CloseShop()
    {
        sign1Animator.SetTrigger("Rise");
        sign2Animator.SetTrigger("Rise");
        sign3Animator.SetTrigger("Rise");
        shopIsOpen = false;

        // Re-enable player input
        weapon.enabled = true;
        buttons.SetActive(false);
    }

    public void OnBuyAkPressed()
    {
        if (playerData.money >= akPrice)
        {
            playerData.money -= akPrice;
            weaponSpriteRenderer.sprite = akSprite;

            Debug.Log("AK PURCHASED");
            CloseShop();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    public void OnBuyShotgunPressed()
    {
        if (playerData.money >= shotgunPrice)
        {
            playerData.money -= shotgunPrice;
            weaponSpriteRenderer.sprite = shotgunSprite;

            Debug.Log("SHOTGUN PURCHASED");
            CloseShop();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

    public void OnSniperPressed()
    {
        if (playerData.money >= sniperPrice)
        {
            playerData.money -= sniperPrice;
            weaponSpriteRenderer.sprite = sniperSprite;

            Debug.Log("SNIPER PURCHASED");
            CloseShop();
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }

}

