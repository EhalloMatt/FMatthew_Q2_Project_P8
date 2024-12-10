using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinSceneScript : MonoBehaviour
{
    [SerializeField] private AudioClip sceneSwitchSound;
    [SerializeField] private AudioSource audioSource;

    public void Retry()
    {
        if (audioSource != null && sceneSwitchSound != null)
        {
            audioSource.PlayOneShot(sceneSwitchSound);
        }

        StartCoroutine(LoadSceneWithDelay("Map"));
    }

    public void Quit()
    {
        if (audioSource != null && sceneSwitchSound != null)
        {
            audioSource.PlayOneShot(sceneSwitchSound);
        }

        StartCoroutine(QuitWithDelay());
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(sceneSwitchSound.length);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitWithDelay()
    {
        yield return new WaitForSeconds(sceneSwitchSound.length);
        Application.Quit();
    }
}
