using UnityEngine;

public class LU_LightReactToPower : LU_PowerInteraction
{   
    public GameObject _noctis;
    Rigidbody2D _attractorRb;
    [SerializeField] float _lightMoveSpeed = 1.5f;

    private void Start()
    {
        _attractorRb = transform.parent.GetChild(1).GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 directionLight = -(_attractorRb.transform.position - transform.position);

        float targetAngle = Vector2.SignedAngle(Vector2.right, directionLight);

        transform.eulerAngles = new Vector3(0, 0, targetAngle - 90);
    }

    public override void MoveTowards()
    {
        Vector3 directionAttractor = -(_noctis.transform.position - _attractorRb.transform.position);
        
        _attractorRb.AddForce(directionAttractor.normalized * _lightMoveSpeed, ForceMode2D.Impulse);
    }

    public override void MoveAwayFrom()
    {
        Vector3 directionAttractor = _noctis.transform.position - _attractorRb.transform.position;

        _attractorRb.AddForce(directionAttractor.normalized * _lightMoveSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_ElementReceptor>(out LU_ElementReceptor receptor))
        {
            return;
        }
        if (collision.transform.GetChild(1).gameObject.activeSelf)
        {
            collision.GetComponent<LU_CharacterController>().ReturnToSpawn();
        }

    }
}
