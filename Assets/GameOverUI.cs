using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverGroup;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalTimeText;

    private ScoreAndTime scoreAndTime;

    void Start()
    {
        gameOverGroup.SetActive(false);

        // Cache reference for performance
        scoreAndTime = Object.FindFirstObjectByType<ScoreAndTime>();
    }

    public void Show()
    {
        // Update final score
        finalScoreText.text = "Final Score: " + scoreAndTime.score;

        // Update final time
        finalTimeText.text = "Time Survived: " + scoreAndTime.timeSurvived.ToString("F1") + "s";

        // Show the UI
        gameOverGroup.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
