using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    [Header("References")]
    public GameObject gun; // The gun object to be equipped
    public Transform playerHand; // The player's hand where the gun should be attached

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the trigger
        if (collision.CompareTag("Player"))
        {
            
            EquipGun();
        }
    }

    private void EquipGun()
    {
        if (gun != null && playerHand != null)
        {

            // Attach the gun to the player's hand
            gun.transform.SetParent(playerHand);
            gun.transform.localPosition = Vector3.zero; // Position relative to the playerHand
            gun.transform.localRotation = Quaternion.identity; // Reset rotation

            // Ensure the gun is active
            if (!gun.activeSelf)
            {
                gun.SetActive(true);
            }

        }
        else
        {
        }
    }
}
