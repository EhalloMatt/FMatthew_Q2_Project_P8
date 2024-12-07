using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyLockScript : MonoBehaviour
{
    public int requiredGold = 10; // Gold needed to unlock
    public string winSceneName = "WinScene"; // Replace with your win scene name
    private bool isUnlocked = false; // Prevent multiple unlock attempts

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collision detected with: {other.name}");

        if (other.CompareTag("Player") && !isUnlocked)
        {
            GoldCounter goldCounter = FindObjectOfType<GoldCounter>();

            if (goldCounter != null)
            {
                Debug.Log($"Player's Current Gold: {goldCounter.CurrentGold}, Required Gold: {requiredGold}");

                if (goldCounter.CurrentGold >= requiredGold)
                {
                    goldCounter.SpendGold(requiredGold); // Deduct the required gold
                    Unlock(); // Unlock the lock
                }
                else
                {
                    Debug.Log("Not enough gold to unlock this lock!");
                }
            }
            else
            {
                Debug.LogWarning("GoldCounter script not found in the scene!");
            }
        }
    }

    private void Unlock()
    {
        isUnlocked = true;
        Debug.Log("Lock unlocked! Attempting to transition to the win scene...");

        if (Application.CanStreamedLevelBeLoaded(winSceneName))
        {
            SceneManager.LoadScene(winSceneName);
            Debug.Log($"Successfully loaded scene: {winSceneName}");
        }
        else
        {
            Debug.LogError($"Scene '{winSceneName}' not found in Build Settings! Add it to the Build Settings.");
        }
    }
}
