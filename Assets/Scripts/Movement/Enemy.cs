using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;
    public float speed = 5f;

    private float randomDirTimer = 0f;
    private float randomDirDuration = 1f;

    Rigidbody2D rb;

    Vector2 randomDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        randomDirTimer -= Time.deltaTime;

        if (randomDirTimer <= 0)
        {
            RandomMovement();
            randomDirTimer = randomDirDuration;
        }

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

    

    private void RandomMovement()
    {
        randomDir = (Random.insideUnitCircle).normalized;
        rb.velocity = randomDir * speed;

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
