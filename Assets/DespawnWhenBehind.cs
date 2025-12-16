using UnityEngine;

public class DespawnWhenBehind : MonoBehaviour
{
    public Transform player;
    public float distance = 80f;

    void Start()
    {
        // Automatically find the player in the scene
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        if (player.position.x - transform.position.x > distance)
        {
            Destroy(gameObject);
        }
    }
}
