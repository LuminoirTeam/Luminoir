using UnityEngine;

public class LU_LightReactToPower : MonoBehaviour
{
    [SerializeField] GameObject _noctis;
    private Rigidbody2D _attractorRb;
    [SerializeField] float _lightMoveSpeed = 2;

    private void Start()
    {
        _attractorRb = transform.GetChild(0).GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 directionLight = -(_attractorRb.transform.position - transform.position);

        float targetAngle = Vector2.SignedAngle(Vector2.right, directionLight);

        transform.eulerAngles = new Vector3(0, 0, targetAngle - 90);
    }

    public void PointTowardsNoctis()
    {
        Vector3 directionAttractor = -(_noctis.transform.position - _attractorRb.transform.position);
        

        _attractorRb.AddForce(directionAttractor.normalized * _lightMoveSpeed, ForceMode2D.Impulse);
    }

    public void PointAwayFromNoctis()
    {
        //Vector3 directionAttractor = (_attractorRb.transform.position - transform.position);

        //transform.LookAt(_attractorRb.transform.position);

        //_attractorRb.AddForce(directionAttractor.normalized * _lightMoveSpeed, ForceMode2D.Impulse);
    }
}
