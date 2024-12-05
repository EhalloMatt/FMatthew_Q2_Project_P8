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
            Debug.Log("Player picked up the gun");
            EquipGun();
        }
    }

    private void EquipGun()
    {
        if (gun != null && playerHand != null)
        {
            Debug.Log($"Attaching gun '{gun.name}' to player hand '{playerHand.name}'...");

            // Attach the gun to the player's hand
            gun.transform.SetParent(playerHand);
            gun.transform.localPosition = Vector3.zero; // Position relative to the playerHand
            gun.transform.localRotation = Quaternion.identity; // Reset rotation

            // Ensure the gun is active
            if (!gun.activeSelf)
            {
                Debug.LogWarning("Gun was inactive. Activating it.");
                gun.SetActive(true);
            }

            Debug.Log($"Gun '{gun.name}' equipped successfully as a child of '{playerHand.name}'.");
        }
        else
        {
            Debug.LogError("Gun or PlayerHand reference is missing!");
        }
    }
}
