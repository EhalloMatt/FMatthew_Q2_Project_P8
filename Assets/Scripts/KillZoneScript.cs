using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
    [SerializeField] private bool resetOnCollisionWithPlayer = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (resetOnCollisionWithPlayer && collision.CompareTag("Player"))
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.ResetToStart();
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
