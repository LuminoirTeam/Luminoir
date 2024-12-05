using UnityEngine;
using UnityEngine.InputSystem;

public class LU_CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float _playerX;
    public float PlayerSpeed;
    public float JumpingForce;


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_playerX * PlayerSpeed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpingForce);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _playerX = context.ReadValue<Vector2>().x;
    }
}
