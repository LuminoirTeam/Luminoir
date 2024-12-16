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

    private bool _isAttracting = false;
    private bool _isRepelling = false;
    private bool _tryInteract = false;

    private GameObject lumisSpawn;
    private GameObject noctisSpawn;
    private bool _isNoctis;

    public GameObject currentSpawn;
    public LU_Power power; //The variable to access character's power script

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        movementAction = _input.actions["Jump"];
        movementAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).position;

        _isNoctis = GetComponent<LU_SetPlayer>().isNoctis;
        //if( _isNoctis)
        //{
        //    power = power is LU_PowerNoctis;
        //}
    }

    private void FixedUpdate()
    {
        print(_tryInteract);

        Jump();

        if (_isAttracting)
        {
            //if (IsGrounded())
            //{
                power.AttractElement();
            //}
            //else if (_isNoctis)
            //{
                
            //    power.Grappling();
            //}
        }
        if (_isRepelling)
            power.RepelElement();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(movementAction.ReadValue<Vector2>() * _jumpingForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        groundCheck = transform.GetChild(2).position;
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started) { _tryInteract = true; }

        if (context.canceled) { _tryInteract = false; }
    }

    public void ReturnToSpawn()
    {
        if (_isNoctis)
        {
            transform.position = noctisSpawn.transform.position;
        }
        else
        {
            transform.position = lumisSpawn.transform.position;
        }
    }

    public void EnableOrDisablePlayerInput()
    {
        _input.enabled = !_input.enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<LU_CharacterController>(out LU_CharacterController anotherCharacter))
        {
            //anotherCharacter.ReturnToSpawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Entered Checkpoint");
            noctisSpawn = collision.GetComponent<LU_Checkpoint>().noctisSpawn;
            lumisSpawn = collision.GetComponent <LU_Checkpoint>().lumisSpawn;
        }

        if(collision.gameObject.CompareTag("Lever") && _tryInteract)
        {
            collision.GetComponent<Lever>().OpenDoor();
        }
    }
}