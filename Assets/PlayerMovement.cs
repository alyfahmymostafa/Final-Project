using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 10f;
    public bool canMove = true;

    [Header("Lane Switching")]
    public float laneOffset = 3f;
    public float laneChangeSpeed = 10f;
    private int currentLane = 1; // 0 = Right, 1 = Center, 2 = Left
    private Vector3 targetPosition;
    private float startZ;

    [Header("Jump State")]
    public bool isJumping = false;

    [Header("Death State")]
    public bool isDead = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        startZ = transform.position.z;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (canMove && !isDead)
        {
            transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime, Space.World);
            HandleLaneSwitching();
            SmoothLaneMovement();
        }

        HandleJumpInput();
    }

    void HandleJumpInput()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            isJumping = true;

            Invoke(nameof(EndJump), 0.8f);
        }
    }

    void EndJump()
    {
        isJumping = false;
    }

    void HandleLaneSwitching()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane > 0)
        {
            currentLane--;
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane < 2)
        {
            currentLane++;
            UpdateTargetPosition();
        }
    }

    void UpdateTargetPosition()
    {
        float targetZ = startZ + (currentLane - 1) * laneOffset;
        targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
    }

    void SmoothLaneMovement()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPos, laneChangeSpeed * Time.deltaTime);
    }

    // ✅ Trigger falling animation + stop movement
    public void PlayFall()
    {
        if (isDead) return;

        isDead = true;
        canMove = false;
        anim.SetTrigger("Fall");
    }
}
