using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
}
