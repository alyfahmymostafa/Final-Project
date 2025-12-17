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

        // ✅ Lower or mute music while paused (optional)
        AudioManager.Instance.musicSource.volume = 0.2f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        if (pauseButton != null) pauseButton.SetActive(true);

        Time.timeScale = 1f; // unfreeze game
        isPaused = false;

        // ✅ Restore music volume
        AudioManager.Instance.musicSource.volume = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // reset time before switching scenes

        // ✅ Restart music for main menu
        AudioManager.Instance.PlayMusic(AudioManager.Instance.musicSource.clip);

        SceneManager.LoadScene("MainMenu");
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
