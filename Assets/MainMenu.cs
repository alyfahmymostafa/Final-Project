using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject descriptionPanel;

    public void StartGame()
    {
        // ✅ Start background music for gameplay
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicSource.clip);

        SceneManager.LoadScene("DemoScene");
    }

    public void ShowDescription()
    {
        descriptionPanel.SetActive(true);
    }

    public void HideDescription()
    {
        descriptionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
