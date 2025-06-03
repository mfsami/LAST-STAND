using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Enemy enemy;

    public float health = 4;

    private float moveX;
    private float moveY;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Movement();
        
    }

    private void Movement()
    {
        

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // We need to place these 2 values somewhere, make a Vector2 box
        // move is a box that holds 2 nums, horizontal and vertical movement (Vector2)
        Vector2 move = new Vector2(moveX, moveY).normalized;

        rb.velocity = move * speed;

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);

        // Flip sprite based on left and right since same anim
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            TakeDamagePlayer();
        }
    }


    public void TakeDamagePlayer()
    {
        // Change later to public value, differnt damage depending on zombie type
        health -= 1;
        Debug.Log("HEALTH =" + health);

        if (health <= 0)
        {
            ScatterYourSorrowsToTheHeartlessWorld();
        }

        // Moving right
        if (moveX > 0)
        {
            animator.SetTrigger("PlayerDmgWalk");

        }

        else if (moveX < 0)
        {
            animator.SetTrigger("PlayerDmgWalk");
        }

        else
        {
            animator.SetTrigger("PlayerDmgIdle");
        }

        }

    private void ScatterYourSorrowsToTheHeartlessWorld()
    {
        Destroy(gameObject);
    }

    
    
       
    


}
