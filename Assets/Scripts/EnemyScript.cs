using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject deathEffect; // Assign the BloodEffect prefab here

    public int health = 1; // Number of hits the enemy can take

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Spawn the blood effect
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Death effect is not assigned!");
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}
