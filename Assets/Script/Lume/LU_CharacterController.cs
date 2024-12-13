using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LU_CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 groundCheck;
    private Vector3 wallCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float _playerSpeed = 8;
    [SerializeField] private float _jumpingForce = 5;
    [SerializeField] private Vector2 _sizeOfGroundCheckBox = new Vector2(1, 0.5f);
    [SerializeField] private Vector2 _sizeOfWallCheckBox = new Vector2(1f, 1f);

    private InputAction movementAction;
    private PlayerInput _input;

    private bool _isAttracting = false;
    private bool _isRepelling = false;

    private bool _isClingingToWall = false;

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

        groundCheck = transform.GetChild(2).position;
        wallCheck = transform.GetChild(3).position;

        _isNoctis = GetComponent<LU_SetPlayer>().isNoctis;
    }

    private void FixedUpdate()
    {
        Jump();
        CheckIfOutOfBounds();

        if (_isAttracting)
            power.AttractElement();

        if (_isRepelling)
            power.RepelElement();

        //Debug.Log(IsClingingToWall());
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(movementAction.ReadValue<Vector2>() * _jumpingForce, ForceMode2D.Impulse);
        }
    }
    private void CheckIfOutOfBounds()
    {
        if(transform.position.x<=LU_CameraBehaviour.Left || transform.position.x >= LU_CameraBehaviour.Right)
        {
            if(currentSpawn.transform.position.x <= LU_CameraBehaviour.Left || currentSpawn.transform.position.x >= LU_CameraBehaviour.Right)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                ReturnToSpawn();
            }
        }
            
        
    }

    private bool IsGrounded()
    {
        groundCheck = transform.GetChild(0).position;
        Collider2D colliderFound = Physics2D.OverlapBox(groundCheck, _sizeOfGroundCheckBox, 0, groundLayer);
        if (colliderFound == null) { return false; }

        return true;
    }

    private bool IsClingingToWall()
    {
        wallCheck = transform.GetChild(3).position;
        Collider2D colliderFound = Physics2D.OverlapBox(wallCheck, _sizeOfWallCheckBox, 0, groundLayer);
        if (colliderFound == null) { return false; }

        return true;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!IsClingingToWall())
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

    public void ReturnToSpawn()
    {
        transform.position = currentSpawn.transform.position;
    }

    public void EnableOrDisablePlayerInput()
    {
        _input.enabled = !_input.enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<LU_CharacterController>(out LU_CharacterController anotherCharacter))
        {
            anotherCharacter.ReturnToSpawn();
        }

        if (collision.gameObject.layer == wallLayer)
            rb.linearVelocityX = - rb.linearVelocityX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Entered Checkpoint");
            if (currentSpawn.GetComponent<LU_Checkpoint>().currentCharacterInCheckpoint != null && currentSpawn.GetComponent<LU_Checkpoint>().currentCharacterInCheckpoint.TryGetComponent<LU_CharacterController>(out LU_CharacterController anotherCharacter))
            {
                return;
            }
            currentSpawn = collision.gameObject;

        }
    }
}