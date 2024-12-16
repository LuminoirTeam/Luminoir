using UnityEngine;

public class LU_ShadowReactToPower : LU_PowerInteraction
{
    public GameObject _lumis;
    [SerializeField] float _shadowMoveSpeed = 0.2f;
    
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void MoveTowards()
    {
        Vector3 direction = -(_lumis.transform.position - transform.position);

        _rb.AddForce(direction.normalized * _shadowMoveSpeed, ForceMode2D.Impulse);
    }

    public override void MoveAwayFrom()
    {
        Vector3 direction = (_lumis.transform.position - transform.position);

        _rb.AddForce(direction.normalized * _shadowMoveSpeed, ForceMode2D.Impulse);
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
        if (collision.transform.GetChild(0).gameObject.activeSelf)
        {
            collision.excludeLayers = 1 << 13;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_ElementReceptor>(out LU_ElementReceptor receptor))
        {
            return;
        }
        if (collision.transform.GetChild(0).gameObject.activeSelf)
        {
            collision.excludeLayers=~1<<13 ;
        }
    }
}
