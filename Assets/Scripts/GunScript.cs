using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // FirePoint transform
    public float bulletForce = 20f; // Bullet speed

    public void Initialize(GameObject bullet, Transform fire)
    {
        bulletPrefab = bullet;
        firePoint = fire;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletPrefab != null && firePoint != null)
            {
                Fire();
            }
            else
            {
                Debug.LogWarning($"Bullet Prefab: {bulletPrefab}, Fire Point: {firePoint} not assigned!");
            }
        }
    }

    private void Fire()
    {
        Debug.Log("Firing bullet...");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Bullet Rigidbody2D not found!");
        }
    }
}
