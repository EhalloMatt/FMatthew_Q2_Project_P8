using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlyScript : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float moveSpeed = 2f; // Speed at which the fly moves
    public float detectionRange = 5f; // Range within which the fly detects the player
    public int damageAmount = 1; // Damage amount when the fly collides with the player
    public bool showDetectionRange = true; // Toggle to show detection range in the editor

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position; // Save the initial position for resetting
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move back to the starting position
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthScript healthScript = collision.GetComponent<HealthScript>();
        if (healthScript != null)
        {
            healthScript.Damage(damageAmount); // Pass the damage amount when colliding
        }
    }

    // Draw the detection range in the editor
    private void OnDrawGizmosSelected()
    {
        if (showDetectionRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }
}
