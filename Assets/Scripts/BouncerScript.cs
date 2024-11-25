using UnityEngine;

public class BouncePad2D : MonoBehaviour
{
    public float bounceForce = 10f; // Force applied to bounce

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 bounceDirection = Vector2.up; // Upwards in 2D
            rb.velocity = Vector2.zero; // Reset velocity for consistent bounce
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse); // Apply impulse force
        }
    }
}
