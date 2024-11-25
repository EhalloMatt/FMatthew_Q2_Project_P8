using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform handTransform; // Player's hand where the gun will attach
    private GameObject gunInRange; // The gun currently in range of the player

    private void Update()
    {
        // If gun is in range and E is pressed, pick up the gun
        if (gunInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is tagged as "Gun"
        if (other.CompareTag("Gun"))
        {
            gunInRange = other.gameObject; // Store reference to the gun
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Remove reference when the player leaves the gun's trigger area
        if (other.CompareTag("Gun"))
        {
            gunInRange = null;
        }
    }

    private void PickUpGun()
    {
        // Attach the gun to the player's hand
        gunInRange.transform.position = handTransform.position;
        gunInRange.transform.SetParent(handTransform); // Parent the gun to the hand
        gunInRange.GetComponent<Rigidbody2D>().isKinematic = true; // Disable physics
        gunInRange.GetComponent<Collider2D>().enabled = false; // Disable collision
    }
}
