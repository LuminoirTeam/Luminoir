using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private Vector2 _sizeOfWallCheckBox = new Vector2(1, 0.5f); //don't forget to change the value here

    private InputAction movementAction;
    private PlayerInput _input;

    private bool _isAttracting = false;
    private bool _isRepelling = false;
    private bool _tryInteract = false;

    private bool _isNoctis;
    private bool _isFacingRight;

    public Vector3 currentSpawn;
    public LU_Power power; //The variable to access character's power script

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private ParticleSystem _particleRepel;
    private ParticleSystem _particleAttract;

    [SerializeField]

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        movementAction = _input.actions["Jump"];
        movementAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.GetChild(0).position;

        _isNoctis = GetComponent<LU_SetPlayer>().isNoctis;

    }
    private void Start()
    {
        if (!_isNoctis)
        {
            _animator = transform.GetChild(0).GetComponent<Animator>();
            _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

            _particleRepel = transform.GetChild(0).GetChild(3).GetComponent<ParticleSystem>();
            _particleAttract = transform.GetChild(0).GetChild(2).GetComponent<ParticleSystem>();
        }
        else
        {
            _animator = transform.GetChild(1).GetComponent<Animator>();
            _spriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();

            _particleRepel = transform.GetChild(1).GetChild(3).GetComponent<ParticleSystem>();
            _particleAttract = transform.GetChild(1).GetChild(2).GetComponent<ParticleSystem>();
        }
    }

    private void FixedUpdate()
    {
        print(_tryInteract);

        Jump();

        if (_isAttracting)
        {
            if (_isNoctis)
            {
 //               (LU_PowerNoctis) power.
                
                
            }
            power.AttractElement();
            //}
            //else if (_isNoctis)
            //{
                
            //    power.Grappling();
            //}
        }
        if (_isRepelling)
        {
            power.RepelElement();

        }

        if (rb.linearVelocityX >= 0) {_isFacingRight = true; } //to mirror the sprite
        else { _isFacingRight = false; }

        CheckJumpForAnimation(rb.linearVelocityY);

        if (_isFacingRight)
            _spriteRenderer.flipX = false;
        else _spriteRenderer.flipX = true;
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
        groundCheck = transform.GetChild(0).GetChild(0).position;
        Collider2D colliderFound = Physics2D.OverlapBox(groundCheck, _sizeOfGroundCheckBox, 0, groundLayer);
        if (colliderFound == null) { return false; }

        return true;
    }
    private bool IsWalled()
    {
        wallCheck = transform.GetChild(0).GetChild(1).position;
        Collider2D colliderFound = Physics2D.OverlapBox(wallCheck, _sizeOfWallCheckBox, 0, wallLayer);
        if (colliderFound == null) { return false; }

        return true;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _animator.SetBool("isWalking", true);

        if (!IsWalled() || IsGrounded())
            rb.linearVelocityX = context.ReadValue<Vector2>().x * _playerSpeed; //movement

        if (context.canceled) { _animator.SetBool("isWalking", false); } //anim
    }

    public void CallAttractElement(InputAction.CallbackContext context) //called on button input
    {
        if (context.started) { _isAttracting = true; _particleAttract.Play(); }


        if (context.canceled) { _isAttracting = false; _particleAttract.Stop(); }
    }

    public void CallRepelElement(InputAction.CallbackContext context) //called on button input
    {
        if (context.started) { _isRepelling = true; _particleRepel.Play(); }


        if (context.canceled) { _isRepelling = false; _particleRepel.Stop(); }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started) { _tryInteract = true; }

        if (context.canceled) { _tryInteract = false; }
    }

    public void ReturnToSpawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position=currentSpawn;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Entered Checkpoint");
            if (_isNoctis)
            {
                currentSpawn = collision.GetComponent<LU_Checkpoint>().noctisSpawn;
                collision.GetComponent<LU_Checkpoint>()._activationParticles.Play();
                return;
            }
            currentSpawn = collision.GetComponent<LU_Checkpoint>().lumisSpawn;
            collision.GetComponent<LU_Checkpoint>()._activationParticles.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever") && _tryInteract)
        {
            collision.GetComponent<Lever>().OpenDoor();
        }
    }

    private void CheckJumpForAnimation(float yVelocity)
    {
        if (yVelocity > 0.01f)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }
        else if (yVelocity < -0.01f)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", false);
        }
    }
}