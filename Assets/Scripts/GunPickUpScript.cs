using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public GameObject gun;         // Reference to the gun object
    public Transform playerHand;   // Transform where the gun will be attached

    private bool canPickUp = false;

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

    void PickUpGun()
    {
        gun.transform.SetParent(playerHand);
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.identity;
    }
}
