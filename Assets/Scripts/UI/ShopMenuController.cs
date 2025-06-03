using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : MonoBehaviour
{
    public Animator sign1Animator;
    public Animator sign2Animator;
    public Animator sign3Animator;

    private bool shopIsOpen = false;

    public Merchant merchant;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && merchant.playerInRange)
        {
            // Shop is closed and player in range of merchant
            if (!shopIsOpen)
            {
                OpenShop();
            }
            
            else 
            {
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
    }

    private void CloseShop()
    {
        sign1Animator.SetTrigger("Rise");
        sign2Animator.SetTrigger("Rise");
        sign3Animator.SetTrigger("Rise");
        shopIsOpen = false;
    }
}

