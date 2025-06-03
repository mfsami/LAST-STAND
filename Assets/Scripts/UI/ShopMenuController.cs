using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : MonoBehaviour
{
    public Animator sign1Animator;
    public Animator sign2Animator;
    public Animator sign3Animator;

    private bool shopIsOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!shopIsOpen)
            {
                // Open shop
                sign1Animator.SetTrigger("Drop");
                sign2Animator.SetTrigger("Drop");
                sign3Animator.SetTrigger("Drop");
                shopIsOpen = true;
            }
            else
            {
                // Close shop
                sign1Animator.SetTrigger("Rise");
                sign2Animator.SetTrigger("Rise");
                sign3Animator.SetTrigger("Rise");
                shopIsOpen = false;
            }
        }
    }
}

