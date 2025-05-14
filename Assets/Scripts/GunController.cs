using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float fireRate = 0.1f; // bullets per second (0.1 = 10 per sec)
    public Transform firePoint;   // where the bullet spawns

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }

        
    }

    void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseWorldPos - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
}
