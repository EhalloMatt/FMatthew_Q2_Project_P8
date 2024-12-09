using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public Transform playerHand;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Equip gun to player
            transform.SetParent(playerHand);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<BoxCollider2D>().enabled = false; // Disable pickup collider
        }
    }
}
