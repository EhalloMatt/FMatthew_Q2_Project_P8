using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifeTime = 2f; // Bullet lifespan

    private void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy bullet after a certain time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Check for enemy tag
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnHit();
            }

            Destroy(gameObject); // Destroy bullet on hit
        }
    }
}
