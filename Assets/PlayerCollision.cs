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

        // ✅ Play hit sound
        AudioManager.Instance.PlaySFX(AudioManager.Instance.hitSound);

        // ✅ Play falling/game-over sound
        AudioManager.Instance.PlaySFX(AudioManager.Instance.fallSound);

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

        // ✅ Stop background music immediately
        AudioManager.Instance.musicSource.Stop();

        // Stop obstacle spawning
        ObstacleSpawner spawner = Object.FindFirstObjectByType<ObstacleSpawner>();
        if (spawner != null)
            spawner.enabled = false;
    }
}
