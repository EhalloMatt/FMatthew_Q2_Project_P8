using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;  // The bullet prefab
    public Transform firePoint;      // Where bullets spawn
    public float bulletSpeed = 20f;  // Speed of the bullet
    public float fireRate = 0.5f;    // Time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        if (firePoint == null)
        {
            Debug.LogWarning("Fire point is not assigned.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have a Rigidbody2D component.");
        }
    }
}
