using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton; // optional if you have an on‑screen pause button

    private bool isPaused = false;

    void Update()
    {
        // Pause/unpause with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        if (pauseButton != null) pauseButton.SetActive(false);

        Time.timeScale = 0f; // freeze game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        Time.timeScale = 1f; // unfreeze game
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // reset time before switching scenes
        SceneManager.LoadScene("MainMenu");
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
