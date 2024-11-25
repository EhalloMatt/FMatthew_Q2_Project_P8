using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Time before the bullet is destroyed

    void Start()
    {
        // Ignore collision between the bullet and bounce pad only
        GameObject bouncePad = GameObject.FindWithTag("BouncePad"); // Make sure BouncePad is tagged correctly
        Collider2D bulletCollider = GetComponent<Collider2D>();

        if (bouncePad != null && bulletCollider != null)
        {
            Collider2D bouncePadCollider = bouncePad.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(bulletCollider, bouncePadCollider, true); // Ignore collision with bounce pad
        }

        // Destroy bullet after its lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Log what the bullet collided with for debugging
        Debug.Log($"Bullet collided with: {collision.collider.name}");

        // Destroy the bullet on impact with any object
        Destroy(gameObject);
    }
}
