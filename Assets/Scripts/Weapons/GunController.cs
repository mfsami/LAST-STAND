using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.3f;
    public float bulletSpeed = 30f;
    private float fireCooldown = 0f;

    [Header("Gun Shake Settings")]
    private Vector3 originPos;
    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.07f;
    public float shakeTimer = 0f;

    [Header("Orbit Player")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float orbitRadius = 1f;

    [Header("Gun Sounds")]
    public AudioSource audioSource;
    public AudioClip currentGunSound;

    [Header("Looping Gun Audio")]
    public AudioSource loopAudioSource;
    public AudioClip loopGunSound;

    [Header("Weapon Damage")]
    public float damage = 5f; // DEFAULT REVOLVER DAMAGE





    private void Start()
    {
        originPos = transform.localPosition;

    }


    // Update is called once per frame
    void Update()
    {
        LAMouse();
        Debug.DrawLine(playerTransform.position, transform.position, Color.red);


        fireCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0) && fireCooldown <= 0f)
        {
            Shoot();
            GunShake();
            fireCooldown = fireRate;
            shakeTimer = shakeDuration;
        }
        GunShake();
    }

    private void LAMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Get the direction from the player to the mouse
        Vector3 fromPlayerToMouse = mousePos - playerTransform.position;
        Vector3 direction = fromPlayerToMouse.sqrMagnitude < 0.01f ? Vector3.right : fromPlayerToMouse.normalized;

        // Force the gun to always stay at the set orbit radius
        transform.localPosition = direction * orbitRadius;

        // Rotate to face mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Flip gun sprite if mouse is to the left of gun (less) 

        Vector3 scale = transform.localScale;

        if (mousePos.x < transform.position.x)
        {
            scale.y = -Mathf.Abs(scale.y);
        }
        else
        {
            scale.y = Mathf.Abs(scale.y);
        }

        transform.localScale = scale;


    }

    private void Shoot()
    {
        // Get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Direction vector from guns gunpoint to mouse
        // Subtarcting positions gives vector pointing from gun to mouse
        // normalize to remove distance, we only need direction
        Vector3 direction = transform.right;

        // Calculate rotation angle based on direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        // Spawns bullet at firepoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetGunDmg(damage); // from current gun
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        if (currentGunSound != null && audioSource != null)
            audioSource.PlayOneShot(currentGunSound);
    }

    private void GunShake()
    {
        if (shakeTimer > 0)
        {
            Vector3 shakeOffset = (Vector3)(Random.insideUnitCircle * shakeAmount);
            transform.position += shakeOffset;
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0)
            {
                // Let LAMouse() re-align next frame
            }
        }
    }

    public void SetGunStats(float newFireRate, float newBulletSpeed)
    {
        fireRate = newFireRate;
        bulletSpeed = newBulletSpeed;
    }





}
