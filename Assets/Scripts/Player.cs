using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
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
    }
}
