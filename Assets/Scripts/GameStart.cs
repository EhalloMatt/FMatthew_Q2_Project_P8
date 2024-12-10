using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class MainMenu : MonoBehaviour
{
    // Function to load the game scene
    public void StartGame()
    {
        SceneManager.LoadScene("Map"); 
    }
}
