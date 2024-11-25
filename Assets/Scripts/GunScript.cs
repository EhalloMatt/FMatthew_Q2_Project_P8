using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint; // Reference to the fire point of the gun
    public GameObject bulletPrefab; // Bullet prefab to instantiate
    public float bulletForce = 20f; // Public variable for bullet speed

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Fire();
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet Prefab: " + bulletPrefab + ", Fire Point: " + firePoint + " not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
