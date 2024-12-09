using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
    // Checkbox to decide if the KillZone should reset the player
    [SerializeField] private bool resetOnCollisionWithPlayer = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (resetOnCollisionWithPlayer && collision.CompareTag("Player"))
        {
            // Reset the player to the start position
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.ResetToStart();
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(collision.gameObject);
        }
        else if (resetOnCollisionWithPlayer && collision.CompareTag("Fake"))
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
