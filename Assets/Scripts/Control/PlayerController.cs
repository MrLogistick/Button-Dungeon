using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Walking, sprinting, jumping

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    float playerSpeed;
    float horizontal;

    [SerializeField] float jumpForce;
    [SerializeField] float jetGravity;
    [SerializeField] float normGravity;
    [SerializeField] float fallGravity;
    [SerializeField] float coyoteTime;
    float coyoteTimeElapsed;

    [HideInInspector]
    public bool hasJetpack = false;

    Rigidbody2D rb;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        playerSpeed = walkSpeed;
    }

    void Update() {
        if (rb.linearVelocityY < 0) {
            rb.gravityScale = fallGravity;
        }
        else {
            if (hasJetpack) {
                rb.gravityScale = jetGravity;
            }
            else {
                rb.gravityScale = normGravity;
            }
        }

        if (IsGrounded()) {
            coyoteTimeElapsed = coyoteTime;
        }
        else {
            coyoteTimeElapsed -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J)) {
            hasJetpack = true;
        }
    }

    void FixedUpdate() {
        rb.linearVelocityX = horizontal * playerSpeed;
    }

    public void MoveInput(InputAction.CallbackContext context) {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void SprintInput(InputAction.CallbackContext context) {
        if (context.performed) {
            playerSpeed = runSpeed;
        }

        if (context.canceled) {
            playerSpeed = walkSpeed;
        }
    }

    public void JumpInput(InputAction.CallbackContext context) {
        if (context.performed && coyoteTimeElapsed > 0) {
            rb.linearVelocityY += jumpForce;
        }

        if (context.canceled && rb.linearVelocityY > 0) {
            rb.linearVelocityY *= 0.5f;
            coyoteTimeElapsed = 0;
        }
    }

    bool IsGrounded() {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.48f, 0.1f), 0, groundLayer);
    }
}