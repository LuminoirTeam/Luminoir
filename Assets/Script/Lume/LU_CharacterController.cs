using UnityEngine;
using UnityEngine.InputSystem;

public class LU_CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _playerSpeed = 8;
    [SerializeField] private float _jumpingForce = 5;
    [SerializeField] private Vector2 _sizeOfGroundCheckBox = new Vector2(1, 0.5f);

    private InputAction movementAction;
    private PlayerInput _input;

    [SerializeField] internal LU_Power _power; //The variable to acces character's power script

    private Vector3 _spawnPos;
    private bool _isAttracting = false;
    private bool _isRepelling = false;

    //public bool DEBUG_isNoctis;


    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        movementAction = _input.actions["Jump"];
        movementAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).position;
    }
    private void Start()
    {
        _spawnPos = transform.position;
    }

    private void Update()
    {
        CheckIfOutOfBonds();
        Jump();

        if (_isAttracting)
            _power.AttractElement();

        if (_isRepelling)
            _power.RepelElement();
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
        Collider2D colliderFound = Physics2D.OverlapBox(groundCheck, _sizeOfGroundCheckBox, 0, groundLayer);
        if (colliderFound == null) { return false; }

        return true;
    }

    public void Move(InputAction.CallbackContext context)
    {
        rb.linearVelocityX = context.ReadValue<Vector2>().x * _playerSpeed;
    }

    public void CallAttractElement(InputAction.CallbackContext context) //called on button input
    {
        if (context.started) { _isAttracting = true; }
            

        if (context.canceled) { _isAttracting = false; }
            
    }

    public void CallRepelElement(InputAction.CallbackContext context) //called on button input
    {
        if (context.started) { _isRepelling = true; }
            

        if (context.canceled) { _isRepelling = false; }
            
    }
    private void CheckIfOutOfBonds()
    {
        if (LU_CameraBehaviour.Left >= transform.position.x)
        {
            ReturnToSpawn();
            return;
        }
        if (LU_CameraBehaviour.Right <= transform.position.x)
        {
            ReturnToSpawn();
        }
    }
    public void ReturnToSpawn()
    {
        transform.position = _spawnPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<LU_CharacterController>(out LU_CharacterController anotherCharacter))
        {
            anotherCharacter.ReturnToSpawn();
        }
    }

}
