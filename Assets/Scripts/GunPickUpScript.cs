using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform handTransform; // The player's hand position to attach the gun
    private GameObject gunObject; // Reference to the gun's GameObject
    private bool isNearGun = false; // To check if the player is near the gun
    public bool hasGun = false; // To track if the player has picked up the gun

    void Update()
    {
        // Check if the player presses E and is near the gun
        if (isNearGun && Input.GetKeyDown(KeyCode.E) && !hasGun)
        {
            PickUpGun();
        }

        // Allow the player to drop the gun with Q
        if (hasGun && Input.GetKeyDown(KeyCode.Q))
        {
            DropGun();
        }
    }

    // Detect when the player is near the gun
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearGun = true; // Player is near the gun
            Debug.Log("Player is near the gun, press E to pick it up.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearGun = false; // Player is no longer near the gun
        }
    }

    void PickUpGun()
    {
        gunObject = this.gameObject; // Get the gun GameObject this script is attached to

        // Attach the gun to the player's hand
        gunObject.transform.SetParent(handTransform); // Parent the gun to the player's hand
        gunObject.transform.localPosition = Vector3.zero; // Align with hand position
        gunObject.transform.localRotation = Quaternion.identity; // Reset rotation

        // Optionally, disable physics to avoid unexpected behavior when picking it up
        Rigidbody2D rb = gunObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true; // Disable physics to ensure it follows the hand
        }

        // Set hasGun to true to prevent picking up the gun again
        hasGun = true;

        Debug.Log("Gun picked up and attached to the player's hand.");
    }

    void DropGun()
    {
        // Drop the gun from the player's hand
        gunObject.transform.SetParent(null); // Remove parent
        Rigidbody2D rb = gunObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false; // Re-enable physics to allow it to fall
        }

        hasGun = false; // The player no longer has the gun
        Debug.Log("Gun dropped.");
    }
}
