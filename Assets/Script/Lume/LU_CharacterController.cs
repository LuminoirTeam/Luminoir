using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LU_CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private Vector2 _sizeOfGroundCheckBox;
    private InputAction movementAction;
    private PlayerInput _input;

    [SerializeField] LU_Power _power;

    //public bool DEBUG_isNoctis;


    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        movementAction = _input.actions["Jump"];
        movementAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).position;
    }
    private void Update()
    {
        Jump();

        //if (Input.GetKey(KeyCode.Joystick1Button15))
        //    _power.AttractElement();

        //if (Input.GetKey(KeyCode.Joystick1Button13))
        //    _power.RepelElement();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(movementAction.ReadValue<Vector2>(), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        groundCheck = transform.GetChild(0).position;
        Collider2D colliderFound = Physics2D.OverlapBox(groundCheck, _sizeOfGroundCheckBox,0, groundLayer);
        if (colliderFound == null) { return false; }

        return true;
    }

    public void Move(InputAction.CallbackContext context)
    {
        rb.linearVelocityX = context.ReadValue<Vector2>().x * _playerSpeed;
    }

    public void CallAttractElement()
    {
        _power.AttractElement();
    }

    public void CallRepelElement()
    {
        _power.RepelElement();
    }
}
