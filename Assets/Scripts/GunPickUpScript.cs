using UnityEngine;

public class GunPickUpScript : MonoBehaviour
{
    public GameObject gunPrefab; // Assign your gun prefab here
    private bool isGunPickedUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isGunPickedUp)
        {
            GunScript gunScript = other.GetComponentInChildren<GunScript>();
            if (gunScript == null)
            {
                // Attach gunPrefab to player without instantiating a new clone
                GameObject gun = Instantiate(gunPrefab, other.transform);
                gun.transform.localPosition = Vector3.zero; // Adjust as needed
                gun.transform.localRotation = Quaternion.identity;

                isGunPickedUp = true;
                Debug.Log("Gun picked up!");
            }

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
