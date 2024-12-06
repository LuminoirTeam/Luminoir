using UnityEngine;
using UnityEngine.InputSystem;

public class LU_PlayerController : MonoBehaviour
{
    // Public variables for Rigidbody2D, ground check Transform, and ground layer mask
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Private variables for horizontal movement, speed, jumping power, and facing direction
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Vector2 _sizeOfGroundCheckBox = new Vector2(0.2f, 0.2f);

    // FixedUpdate is called at a fixed interval and is used for physics calculations

    // Method to handle jump input
    public void Jump(InputAction.CallbackContext context)
    {
        // If the jump action is performed and the player is grounded, set the vertical velocity to jumping power
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // If the jump action is canceled and the player is moving upwards, reduce the vertical velocity
        if (context.canceled && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    // Method to check if the player is grounded
    private bool IsGrounded()
    {
        // Check for overlap with ground layer at the ground check position
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return Physics2D.OverlapBox(groundCheck.position,_sizeOfGroundCheckBox , groundLayer);
    }

    // Method to handle movement input
    public void Move(InputAction.CallbackContext context)
    {
        // Read the horizontal input value from the context
        horizontal = context.ReadValue<Vector2>().x;
    }
}