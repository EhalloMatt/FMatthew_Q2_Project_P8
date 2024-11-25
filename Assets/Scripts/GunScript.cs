using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint; // The point from where bullets are fired
    public GameObject bulletPrefab; // Bullet prefab to instantiate
    public float bulletSpeed = 10f; // Speed of the bullet
    public bool hasGun = false; // Track if player is holding the gun

    void Update()
    {
        if (hasGun)
        {
            // Check for shooting input
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                Shoot();
            }
        }
    }

    public void EquipGun()
    {
        hasGun = true; // Mark the gun as equipped
        Debug.Log("Gun equipped!");
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * bulletSpeed; // Add velocity to the bullet
            }
            Debug.Log("Bullet fired!");
        }
        else
        {
            Debug.LogWarning("FirePoint or BulletPrefab is missing!");
        }
    }
}
