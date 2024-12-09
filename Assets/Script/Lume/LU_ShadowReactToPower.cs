using UnityEngine;

public class LU_ShadowReactToPower : MonoBehaviour
{
    [SerializeField] GameObject _lumis;
    [SerializeField] float _shadowMoveSpeed;
    
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowardsLumis()
    {
        Vector2 direction = -(_lumis.transform.position - transform.position);

        _rb.AddForce(direction.normalized * _shadowMoveSpeed, ForceMode2D.Impulse);
    }

    public void MoveAwayFromLumis()
    {
        Vector2 direction = (_lumis.transform.position - transform.position);

        _rb.AddForce(direction.normalized * _shadowMoveSpeed, ForceMode2D.Impulse);
    }
}
