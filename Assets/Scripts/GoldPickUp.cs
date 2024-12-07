using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int goldAmount = 1; // Amount of gold this coin gives

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the Player
        if (collision.CompareTag("Player"))
        {
            // Find the GoldCounter script and add gold
            GoldCounter goldCounter = FindObjectOfType<GoldCounter>();
            if (goldCounter != null)
            {
                goldCounter.AddGold(goldAmount); // Add gold
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
