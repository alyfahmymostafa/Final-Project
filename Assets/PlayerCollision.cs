using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameOverUI gameOverUI;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle"))
            return;

        if (movement.isJumping)
            return;

        if (movement.isDead)
            return;

        movement.PlayFall();
        movement.isDead = true;

        DisableGameplay();

        // ✅ Show Game Over UI
        gameOverUI.Show();
    }

    void DisableGameplay()
    {
        // Stop player movement
        movement.canMove = false;

        // ✅ Stop score + time
        Object.FindFirstObjectByType<ScoreAndTime>().Stop();

        // Stop obstacle spawning
        ObstacleSpawner spawner = Object.FindFirstObjectByType<ObstacleSpawner>();
        if (spawner != null)
            spawner.enabled = false;
    }
}
