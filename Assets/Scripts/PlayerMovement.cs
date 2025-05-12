using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private string currentState = "";
    private string lastMoveDirection = "Down"; // Tracks last movement for idle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(moveX, moveY);

        if (input.magnitude < 0.1f)
        {
            movement = Vector2.zero;
        }
        else
        {
            movement = input.normalized;

            string direction = GetDirectionName(movement);
            lastMoveDirection = direction;
            PlayAnimation("Drive_" + direction);
        }

        if (movement == Vector2.zero)
        {
            PlayAnimation("Idle_" + lastMoveDirection);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    string GetDirectionName(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle + 360f) % 360f;

        if (angle >= 348.75f || angle < 11.25f) return "Right";
        if (angle >= 11.25f && angle < 33.75f) return "Q2_1";      // was Q1_1
        if (angle >= 33.75f && angle < 56.25f) return "Q2_2";      // was Q1_2
        if (angle >= 56.25f && angle < 78.75f) return "Q2_3";      // was Q1_3
        if (angle >= 78.75f && angle < 101.25f) return "Up";
        if (angle >= 101.25f && angle < 123.75f) return "Q1_1";    // was Q2_1
        if (angle >= 123.75f && angle < 146.25f) return "Q1_2";    // was Q2_2
        if (angle >= 146.25f && angle < 168.75f) return "Q1_3";    // was Q2_3
        if (angle >= 168.75f && angle < 191.25f) return "Left";
        if (angle >= 191.25f && angle < 213.75f) return "Q3_1";
        if (angle >= 213.75f && angle < 236.25f) return "Q3_2";
        if (angle >= 236.25f && angle < 258.75f) return "Q3_3";
        if (angle >= 258.75f && angle < 281.25f) return "Down";
        if (angle >= 281.25f && angle < 303.75f) return "Q4_1";
        if (angle >= 303.75f && angle < 326.25f) return "Q4_2";
        return "Q4_3";
    }




    void PlayAnimation(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
