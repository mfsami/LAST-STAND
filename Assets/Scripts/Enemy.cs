using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage(int dmgDealt)
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
