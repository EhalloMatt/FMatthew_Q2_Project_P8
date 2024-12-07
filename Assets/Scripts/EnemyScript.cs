using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 3; // Enemy health
    public int goldReward = 5; // Amount of gold to give on death
    public GameObject deathEffect; // Assign a particle effect for death (optional)
    private bool isDead = false; // Flag to prevent multiple death triggers

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Prevent taking damage after death

        health -= damage; // Subtract health

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // Prevent multiple triggers
        isDead = true;

        // Play death effect
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Add gold to the player
        GoldCounter goldCounter = FindObjectOfType<GoldCounter>();
        if (goldCounter != null)
        {
            goldCounter.AddGold(goldReward);
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}
