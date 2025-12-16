using UnityEngine;

public class PositionBasedLoop : MonoBehaviour
{
    public Transform startPoint;
    public float loopX = -220f;

    void Update()
    {
        if (transform.position.x >= loopX)
        {
            transform.position = startPoint.position;
        }
    }
}
