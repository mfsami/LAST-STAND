using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float bulletSpeed = 10f;
    //private Vector2 direction;

    //public void SetDirection(Vector2 dir)
    //{
    //    direction = dir.normalized;
    //}

    //void Update()
    //{
    //    transform.position += (Vector3)(direction * bulletSpeed * Time.deltaTime);
    //}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
