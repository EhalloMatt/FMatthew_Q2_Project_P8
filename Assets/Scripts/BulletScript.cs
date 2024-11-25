using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifetime); // Automatically destroy bullet after a set time
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add collision handling here if necessary
        Destroy(gameObject);
    }
}
