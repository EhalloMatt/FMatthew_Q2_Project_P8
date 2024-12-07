using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public int goldAmount = 1;
    public AudioClip pickupSound;
    [Range(0, 1)] public float pickupVolume = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        // Add AudioSource at runtime
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (pickupSound == null)
        {
            Debug.LogWarning($"Pickup sound not assigned to GoldPickup script on {gameObject.name}");
        }
        else
        {
            Debug.Log($"Pickup sound assigned correctly to GoldPickup script on {gameObject.name}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add gold to player
            Debug.Log($"Player picked up {goldAmount} gold!");

            // Play pickup sound if assigned
            if (pickupSound != null)
            {
                audioSource.volume = pickupVolume; // Set volume
                audioSource.PlayOneShot(pickupSound);
            }

            // Destroy the gold object after pickup
            Destroy(gameObject);
        }
    }
}
