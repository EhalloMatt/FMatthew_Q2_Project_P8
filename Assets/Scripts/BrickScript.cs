using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] private bool canBreakByBullet = true;
    [SerializeField] private GameObject breakEffectPrefab; // Drag your "Particle System" prefab here in the Inspector
    [SerializeField] private AudioClip destroySound; // Drag your destruction sound here in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBreakByBullet && collision.CompareTag("Bullets"))
        {
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

            // Play the destruction sound
            PlayDestroySound();

            Destroy(gameObject); // Destroy the brick
        }
    }

    private void PlayDestroySound()
    {
        if (destroySound != null)
        {
            // Create a temporary audio object to play the sound
            GameObject audioObject = new GameObject("TempAudio");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = destroySound;
            audioSource.Play();

            // Destroy the audio object after the clip finishes playing
            Destroy(audioObject, destroySound.length);
        }
    }
}
