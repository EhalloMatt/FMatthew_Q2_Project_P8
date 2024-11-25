using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint; // Where bullets spawn
    public float bulletSpeed = 10f; // Bullet speed
    private BulletPool bulletPool; // Reference to the bullet pool

    private void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletPool != null)
        {
            GameObject bullet = bulletPool.GetBullet();
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
            }
        }
    }
}
