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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearGun = true;
            Debug.Log("Player is near the gun. Press E to pick it up.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearGun = false;
        }
    }

    void PickUpGun()
    {
        gunObject = gameObject; // Get the gun GameObject this script is attached to

        // Attach the gun to the player's hand
        gunObject.transform.SetParent(handTransform);
        gunObject.transform.localPosition = Vector3.zero;
        gunObject.transform.localRotation = Quaternion.identity;

        Rigidbody2D rb = gunObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true; // Disable physics for gun
        }

        hasGun = true;
        Debug.Log("Gun picked up!");
    }
}
