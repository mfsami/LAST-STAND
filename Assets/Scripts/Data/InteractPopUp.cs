using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPopUp : MonoBehaviour
{
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        

        
    }

    public void Show()
    {
        
        animator.SetTrigger("PopUp");
    }

    public void Hide()
    {
        animator.SetTrigger("Drop");
        
    }
}