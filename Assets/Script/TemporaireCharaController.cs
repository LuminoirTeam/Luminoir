/*using UnityEngine;
using UnityEngine.InputSystem;

public class Temp : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform groundCheck;
    private float _playerX;

    public float PlayerSpeed;
    public float JumpingForce;

    [SerializeField] public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<Transform>();
    }

    private void FixedUpdate()
    {

    }
    public void Move(InputAction.CallbackContext context)
    {
        _playerX = context.ReadValue<Vector2>().x;
        rb.AddForce();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            
        }

        if (context.canceled)
        {
            
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}*/