using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public int goldValue = 1;
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GoldCounter goldCounter = FindObjectOfType<GoldCounter>();
            if (goldCounter != null)
            {
                goldCounter.AddGold(goldValue);
            }

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject); // Remove the gold pickup after collection
        }
    }
}
