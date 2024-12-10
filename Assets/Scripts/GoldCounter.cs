using UnityEngine;
using TMPro;  // Include TextMeshPro namespace

public class GoldCounter : MonoBehaviour
{
    public static GoldCounter Instance; // Singleton for easy access
    public int totalGold = 0; // The total amount of gold
    public TextMeshProUGUI goldText; // Reference to the TextMeshPro text component

    private void Awake()
    {
        // Ensure only one instance of GoldCounter exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate if it exists
        }
    }

    private void Start()
    {
        // Initialize the gold text display
        UpdateGoldDisplay();
    }

    // Property to get the current amount of gold
    public int CurrentGold
    {
        get { return totalGold; }
    }

    // Method to add gold to the total
    public void AddGold(int amount)
    {
        totalGold += amount;
        UpdateGoldDisplay(); // Update the UI text whenever gold is added
    }

    // Method to spend (or deduct) gold
    public bool SpendGold(int amount)
    {
        if (totalGold >= amount)
        {
            totalGold -= amount;
            UpdateGoldDisplay(); // Update the UI text whenever gold is spent
            return true; // Successfully spent gold
        }
        else
        {
            return false; // Not enough gold to spend
        }
    }

    // Method to update the gold display in the UI
    private void UpdateGoldDisplay()
    {
        // Ensure we only update if goldText is assigned
        if (goldText != null)
        {
            goldText.text = "Gold: " + totalGold.ToString();
        }
    }
}
