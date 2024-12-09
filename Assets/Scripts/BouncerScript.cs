using UnityEngine;

public class BouncePad2D : MonoBehaviour
{
    public float bounceForce = 10f; // Force applied to bounce
    public AudioClip bounceSound;  // Sound to play on collision
    private AudioSource audioSource;

    private void Start()
    {
        // Ensure the bounce pad has an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 bounceDirection = Vector2.up; // Upwards in 2D
                rb.velocity = Vector2.zero; // Reset velocity for consistent bounce
                rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse); // Apply impulse force
            }

            // Play the bounce sound if one is assigned
            if (bounceSound != null)
            {
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }
}
