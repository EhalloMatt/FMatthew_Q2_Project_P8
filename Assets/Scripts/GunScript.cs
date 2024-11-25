using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint; // Where bullets spawn
    public GameObject bulletPrefab; // The bullet prefab
    public float bulletForce = 20f; // Speed of the bullet

    private Camera mainCamera; // Reference to the main camera

    private void Start()
    {
        mainCamera = Camera.main; // Find the main camera
    }

    private void Update()
    {
        RotateGunToMouse();

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Fire();
        }
    }

    private void RotateGunToMouse()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not assigned or found.");
            return;
        }

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure z is zero for 2D

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet Prefab or Fire Point not assigned!");
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
