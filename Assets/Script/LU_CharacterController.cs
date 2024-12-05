using UnityEngine;
using UnityEngine.InputSystem;

public class LU_CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;

    [SerializeField] float _playerSpeed;
    [SerializeField] float _jumpSpeed;

    private Vector2 _moveDirection;

    public InputActionReference MoveAction;
    public InputActionReference JumpAction;

    private bool _isGrounded;
    private bool _hasJumped;

    private void Update()
    {
        _moveDirection = MoveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = (_moveDirection.x * _playerSpeed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
            _rb.linearVelocityY = (Vector2.up.y * _jumpSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            _isGrounded = false;
    }

    //[SerializeField]
    //private float _playerSpeed = 2.0f;
    //[SerializeField]
    //private float _jumpHeight = 1.0f;
    //[SerializeField] Rigidbody2D _rb;

    //private Vector3 _playerVelocity;
    //private bool _isGrounded;

    //private Vector2 _movementInput = Vector2.zero;
    //private bool _hasJumped;

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    _movementInput = context.ReadValue<Vector2>();
    //}

    //public void OnJump(InputAction.CallbackContext context)
    //{
    //    _hasJumped = context.ReadValue<bool>();
    //    _hasJumped = context.action.triggered;
    //}

    //void Update()
    //{
    //    if (_isGrounded && _playerVelocity.y < 0)
    //    {
    //        _playerVelocity.y = 0f;
    //    }

    //    Vector2 move = new Vector2(_movementInput.x, 0);
    //    _rb.linearVelocity = new Vector2(move.x * Time.deltaTime * _playerSpeed, move.y);

    //    //if ((_hasJumped) && _isGrounded)
    //    //{
    //    //    _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f);
    //    //}

    //    //_controller.Move(_playerVelocity * Time.deltaTime);
    //}
}
