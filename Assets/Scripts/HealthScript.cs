using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 5; // Maximum hearts the player can have
    public int currentHealth = 3; // Starting hearts
    public GameObject[] heartContainers; // Array for heart sprites

    void Start()
    {
        UpdateHealthDisplay();
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthDisplay();

        if (currentHealth == 0)
        {
            LoseGame();
        }
    }

    public void AddHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            heartContainers[i].SetActive(i < currentHealth);
        }
    }

    private void LoseGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
    }
}
