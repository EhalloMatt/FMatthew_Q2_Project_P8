using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage to inflict

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthScript healthScript = collision.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.Damage(damageAmount);
        }
    }
}
