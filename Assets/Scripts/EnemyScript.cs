using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hitEffectPrefab; // Drag your particle effect prefab here.

    public void OnHit()
    {
        if (hitEffectPrefab != null)
        {
            // Instantiate the hit effect
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Hit Effect Prefab not assigned!");
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}
