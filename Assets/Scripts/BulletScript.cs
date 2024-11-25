using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject deathEffect; // Assign the effect prefab in the inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.CompareTag("Enemy"))
        {
            // Instantiate the death effect at the enemy's position and rotation
            Instantiate(deathEffect, collision.transform.position, Quaternion.identity);

            // Destroy the enemy object
            Destroy(collision.gameObject);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
