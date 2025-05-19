using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;
    public float speed = 5f;

    Rigidbody2D rb;
    Vector2 randomDir;
    Transform target;
    Vector2 moveDir;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Identify Player in scene and reference transform values
        target = GameObject.Find("Player").transform;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmgDealt)
    {
        health -= dmgDealt;
        Debug.Log("Enemy health :" + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
        HandleAnimations();
    }


    private void FollowTarget()
    {
        if (target)
        {
            // Calculates direction vector from enemy to player
            Vector3 direction = (target.position - transform.position).normalized;
            moveDir = direction;

            // Assign velocity to enemy in that direction
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;
        }
    }

    private void HandleAnimations()
    {
        // Set animations based on direction
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);

        // Flip since left and right uses same animation
        if (moveDir.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
