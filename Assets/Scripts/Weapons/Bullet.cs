using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    public float dmgDealt = 5f;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get enemy component from the object we hit
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null) 
            { 
                enemy.TakeDamage(dmgDealt);
                Destroy(gameObject);
            }

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetGunDmg(float newDmg)
    {
        dmgDealt = newDmg;
        
    }
}
