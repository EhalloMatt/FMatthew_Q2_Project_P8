using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform rightHand; // Reference to the player's right hand

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Gun picked up!");
            transform.SetParent(rightHand); // Parent the gun to the right hand
            transform.localPosition = Vector3.zero; // Reset position
            transform.localRotation = Quaternion.identity; // Reset rotation
        }
    }
}
