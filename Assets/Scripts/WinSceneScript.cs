using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Map"); // Replace "Map" with the name of your main game scene
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Works only in a built application
    }
}
