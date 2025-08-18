using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    public GameObject settingsPanel;
    public AudioSource musicSource;
    [SerializeField] private GameObject fpsCounterObject;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = Mathf.Clamp01(value); // ensures always between 0–1
            Debug.Log("Volume set to: " + musicSource.volume);
        }
    }
    public void ToggleFPS(bool show)
    {
        if (fpsCounterObject != null)
        {
            fpsCounterObject.SetActive(show);
        }
        else
        {
            Debug.LogWarning("FPS Counter object not assigned in Inspector!");
        }

    }
}
