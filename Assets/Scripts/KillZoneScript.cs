using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for the player tag
        if (collision.CompareTag("Player"))
        {
            // Reset the player to the start position
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.ResetToStart();
            }
        }
        // Check for the enemy tag
        else if (collision.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);
        }
        // Check for bricks with the "Fake" tag
        else if (collision.CompareTag("Fake"))
        {
            // Reset the player to the start position
            PlayerScript playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.ResetToStart();
            }
        }
    }
}
