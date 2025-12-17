using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private float rotateSpeed = 180f; // degrees per second

    private void Update()
    {
        // Spin the coin around the Y axis
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked up coin +" + value);

            // ✅ Play coin sound
            AudioManager.Instance.PlaySFX(AudioManager.Instance.coinSound);

            // ✅ Add score using the new Unity API
            Object.FindFirstObjectByType<ScoreAndTime>().AddScore(value);

            Destroy(gameObject);
        }
    }
}
