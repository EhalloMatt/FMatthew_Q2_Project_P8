using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public int CurrentGold { get; private set; } // Holds the current gold count
    public TextMeshProUGUI goldCounterText; // Reference to the TextMeshPro UI text

    void Start()
    {
        UpdateGoldUI(); // Initialize UI with the current gold amount
    }

    public void AddGold(int amount)
    {
        CurrentGold += amount;
        Debug.Log($"Gold added. Current Gold: {CurrentGold}");
        UpdateGoldUI(); // Update UI whenever gold is added
    }

    public void SpendGold(int amount)
    {
        CurrentGold -= amount;
        Debug.Log($"Gold spent. Current Gold: {CurrentGold}");
        UpdateGoldUI(); // Update UI whenever gold is spent
    }

    private void UpdateGoldUI()
    {
        if (goldCounterText != null)
        {
            goldCounterText.text = $"Gold: {CurrentGold}"; // Update the gold counter text
        }
        else
        {
            Debug.LogWarning("Gold Counter TextMeshPro reference is not assigned!");
        }
    }
}
