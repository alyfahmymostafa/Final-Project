using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private float rotateSpeed = 180f; // degrees per second
    [SerializeField] private float verticalOffset = 0.5f; // local Y bump to lift coin

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

            Destroy(gameObject);
        }
    }
}
