using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;


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


}
