using UnityEngine;
using TMPro;

public class ScoreAndTime : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public int score = 0;
    public float timeSurvived = 0f;

    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        // Update time
        timeSurvived += Time.deltaTime;
        timeText.text = "Time: " + timeSurvived.ToString("F1") + "s";

        // Score updates when you pick up coins (you already have this logic)
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void Stop()
    {
        isRunning = false;
    }
}
