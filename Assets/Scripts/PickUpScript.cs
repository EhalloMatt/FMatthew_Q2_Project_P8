using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public int healthAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthScript healthScript = other.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.AddHealth(healthAmount);
            Destroy(gameObject); // Destroy the health pickup after use
        }
    }
}
