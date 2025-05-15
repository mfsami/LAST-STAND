using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float fireRate = 0.05f;
    public float bulletRange = 15f;
    public float spreadAmount = 5f; // degrees
    public LineRenderer linePrefab; // assign a dashed or custom material line
    public Transform firePoint;

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer >= fireRate)
        {
            Fire();
            fireTimer = 0f;
        }

        RotateGun();
    }

    void Fire()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - firePoint.position).normalized;

        
        float spread = Random.Range(-spreadAmount, spreadAmount);
        direction = Quaternion.Euler(0, 0, spread) * direction;

        // Cast a ray in the direction
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction, bulletRange);
        Vector3 endPoint = firePoint.position + direction * bulletRange;

        if (hit.collider != null)
        {
            endPoint = hit.point;
            // Optionally: hit.collider.GetComponent<Enemy>()?.TakeDamage();
        }

        
        StartCoroutine(DrawBulletTrail(firePoint.position, endPoint));

        
        Vector3 spreadDir = Quaternion.Euler(0, 0, spread) * direction;

    }

    void RotateGun()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mouse - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    System.Collections.IEnumerator DrawBulletTrail(Vector3 start, Vector3 end)
    {
        LineRenderer line = Instantiate(linePrefab);
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        yield return new WaitForSeconds(0.05f); // short lifespan

        Destroy(line.gameObject);
    }
}

