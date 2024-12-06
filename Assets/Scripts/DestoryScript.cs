using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [Header("Tag to check for collision")]
    [Tooltip("The tag of the objects to destroy on collision")]
    public string targetTag = "Destroyable";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the specified tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the specified tag
        if (other.gameObject.CompareTag(targetTag))
        {
            // Destroy the collided object
            Destroy(other.gameObject);
        }
    }
}
