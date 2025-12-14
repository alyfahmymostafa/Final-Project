using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The player (Remy)
    public Vector3 offset;         // Position offset behind the player
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smooth movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Apply position
        transform.position = smoothedPosition;

        // Always look at the player
        transform.LookAt(target);
    }
}
