using UnityEngine;

public class LU_LightReactToPower : MonoBehaviour
{
    [SerializeField] GameObject _noctis;

    public void PointTowardsNoctis()
    {
        Vector3 direction = -(_noctis.transform.position - transform.position);
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        transform.eulerAngles = new Vector3(0, 0, targetAngle - 90);
    }

    public void PointAwayFromNoctis()
    {
        Vector3 direction = (_noctis.transform.position - transform.position);
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        transform.eulerAngles = new Vector3(0, 0, targetAngle - 90);
    }
}
