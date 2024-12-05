using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] private bool canBreakByBullet = true;
    [SerializeField] private GameObject breakEffectPrefab; // Drag your "Particle System" prefab here in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBreakByBullet && collision.CompareTag("Bullets"))
        {
            Debug.Log("Brick hit by bullet! Destroying brick...");

            // Play the particle effect at the brick's position
            if (breakEffectPrefab != null)
            {
                GameObject effect = Instantiate(breakEffectPrefab, transform.position, Quaternion.identity);
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play(); // Ensure the particle system is triggered
                }
                Destroy(effect, ps.main.duration); // Clean up the particle effect after it's done
            }
            else
            {
                Debug.LogWarning("No break effect prefab assigned to this brick!");
            }

            Destroy(gameObject); // Destroy the brick
        }
    }
}
