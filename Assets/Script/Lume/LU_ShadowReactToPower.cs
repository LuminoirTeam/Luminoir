using UnityEngine;
using UnityEngine.TextCore.Text;

public class LU_ShadowReactToPower : LU_PowerInteraction
{
    [SerializeField] GameObject _lumis;
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

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_PowerNoctis>(out LU_PowerNoctis noctis))
        {
            noctis.GetComponent<LU_CharacterController>().ReturnToSpawn();
        }
    }
}
