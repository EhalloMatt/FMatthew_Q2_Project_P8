using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform playerRightHand;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Parent the gun to the player's right hand
            transform.SetParent(playerRightHand);
            transform.localPosition = Vector3.zero; // Reset position relative to hand
            transform.localRotation = Quaternion.identity; // Reset rotation relative to hand
            transform.localScale = new Vector3(0.15f, 0.15f, 1); // Ensure correct scale
        }
    }
}
