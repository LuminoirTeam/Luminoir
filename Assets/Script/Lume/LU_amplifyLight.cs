using UnityEngine;

public class LU_amplifyLight : MonoBehaviour
{
    [SerializeField] bool _isToggled = false;
    private GameObject _light;
    private GameObject _lightSource;

    private Vector3 _direction;
    private float _targetAngle;

    private void Start()
    {
        _light = transform.parent.GetChild(1).gameObject;

        _light.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_isToggled)
        {
            _direction = _lightSource.transform.position - transform.position;
            _targetAngle = Vector2.SignedAngle(Vector2.right, _direction);

            _light.transform.eulerAngles = new Vector3(0, 0, _targetAngle - 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            _isToggled = true;
            ApplyStateAndRotate(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            _isToggled = false;
            ApplyStateAndRotate(collision.gameObject);
        }
    }

    private void ApplyStateAndRotate(GameObject lightSource)
    {
        _lightSource = lightSource;

        if (_isToggled)
            _light.SetActive(true);
        else
            _light.SetActive(false);
    }
}