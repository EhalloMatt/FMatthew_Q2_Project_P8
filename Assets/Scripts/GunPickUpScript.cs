using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public GameObject gun; // The gun to be picked up
    public Transform playerHand; // The player's hand where the gun attaches

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up the gun");

            // Equip the gun
            EquipGun();

            // Destroy the pickup object only
            Debug.Log("Destroying the pickup object...");
            Destroy(gameObject);
        }
    }

    private void EquipGun()
    {
        if (gun != null && playerHand != null)
        {
            Debug.Log("Attaching gun to player hand...");

            // Attach the gun to the player's hand
            gun.transform.SetParent(playerHand);
            gun.transform.localPosition = Vector3.zero; // Reset position relative to hand
            gun.transform.localRotation = Quaternion.identity; // Reset rotation
            gun.transform.localScale = Vector3.one; // Reset scale

            Debug.Log("Gun equipped successfully.");
        }
        else
        {
            Debug.LogWarning("Gun or PlayerHand reference is missing!");
        }
    }
}
