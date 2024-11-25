using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint; // Where bullets are fired from
    public GameObject bulletPrefab; // Bullet prefab
    public GameObject hitEffectPrefab; // Optional: Hit effect prefab

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming left mouse button fires
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning($"Bullet Prefab: {bulletPrefab}, Fire Point: {firePoint} not assigned!");
            return;
        }

        // Instantiate the bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
