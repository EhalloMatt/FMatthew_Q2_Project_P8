using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform gun; // Reference to the gun
    public Transform playerHand; // Where the gun attaches to the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gun.SetParent(playerHand, worldPositionStays: false); // Ensure it follows the hand's local space
            gun.localPosition = Vector3.zero; // Reset local position
            gun.localRotation = Quaternion.identity; // Reset local rotation
            Debug.Log("Gun picked up and parented to the hand.");
        }
    }
}
