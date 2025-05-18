using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;

    public void TakeDamage(float dmgDealt)
    {
        health -= dmgDealt;
        Debug.Log("Enemy health :" + health);

        if (health <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
