using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool isLeftHand = false; // Track if the gun is in the left hand
    public Transform leftHandPosition; // Position for the left hand
    public Transform rightHandPosition; // Position for the right hand
    public Transform firePoint; // Fire point of the gun (where bullets come out)
    public GameObject bulletPrefab; // Bullet prefab to instantiate
    public float bulletSpeed = 10f; // Speed of the bullet

    private Transform gunTransform; // The gun's transform
    private GunPickUpScript gunPickUpScript; // Reference to the GunPickUpScript to check if player has the gun

    void Start()
    {
        gunTransform = transform;
        gunPickUpScript = FindObjectOfType<GunPickUpScript>(); // Get reference to GunPickUpScript
    }

    void Update()
    {
        // Only allow switching hands and shooting if the player has the gun
        if (gunPickUpScript != null && gunPickUpScript.hasGun)
        {
            // Switch hand positions based on the player's direction (left or right)
            if (isLeftHand)
            {
                SwitchToLeftHand();
            }
            else
            {
                SwitchToRightHand();
            }

            // Shoot bullet on left mouse button click
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                Shoot();
            }

            // Detect which hand the player is using (left or right)
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // If moving left
            {
                SwitchToLeftHand();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // If moving right
            {
                SwitchToRightHand();
            }
        }
    }

    // Switch to left hand
    public void SwitchToLeftHand()
    {
        isLeftHand = true;
        gunTransform.SetParent(leftHandPosition); // Parent the gun to the left hand
        gunTransform.localPosition = new Vector3(0, 0, 0); // Adjust the offset if needed (adjust the X and Y)
        gunTransform.localRotation = Quaternion.identity; // Reset rotation if necessary
        Debug.Log("Gun switched to left hand");
    }

    // Switch to right hand
    public void SwitchToRightHand()
    {
        isLeftHand = false;
        gunTransform.SetParent(rightHandPosition); // Parent the gun to the right hand
        gunTransform.localPosition = new Vector3(0, 0, 0); // Adjust the offset if needed (adjust the X and Y)
        gunTransform.localRotation = Quaternion.identity; // Reset rotation if necessary
        Debug.Log("Gun switched to right hand");
    }

    // Shoot bullet
    public void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Instantiate the bullet at the firePoint position and direction
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Add velocity to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * bulletSpeed; // Use firePoint's right direction
                Debug.Log($"Bullet velocity: {rb.velocity}");
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab or firePoint is not assigned!");
        }
    }
}
