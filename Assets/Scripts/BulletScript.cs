using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject deathEffect; // Assign your particle effect prefab here

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(deathEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
