using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyLockScript : MonoBehaviour
{
    public int requiredGold = 10; // Gold needed to unlock
    public string winSceneName = "WinScene"; // Replace with your win scene name
    private bool isUnlocked = false; // Prevent multiple unlock attempts

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isUnlocked)
        {
            GoldCounter goldCounter = FindObjectOfType<GoldCounter>();

            if (goldCounter != null && goldCounter.CurrentGold >= requiredGold)
            {
                goldCounter.SpendGold(requiredGold); // Deduct the required gold
                Unlock(); // Unlock the lock
            }
        }
    }

    private void Unlock()
    {
        isUnlocked = true;

        if (Application.CanStreamedLevelBeLoaded(winSceneName))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
