using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement; // ← Drag your PlayerMovement component here in Inspector

    void OnTriggerEnter(Collider other)
    {
        // Debug so we can see what's happening
        Debug.Log("Hit: " + other.name + " | isJumping = " + movement.isJumping);

        // Only react to obstacles
        if (!other.CompareTag("Obstacle"))
            return;

        // ✅ Ignore obstacle if jumping
        if (movement.isJumping)
        {
            Debug.Log("Jumped over obstacle: " + other.name);
            return;
        }

        // ✅ Otherwise: Game Over
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
