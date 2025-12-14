using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public bool canMove = true;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            // Move forward in the direction the player is facing
            transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
}
