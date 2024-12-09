using UnityEngine;

public class LU_amplifyLight : MonoBehaviour
{
    [SerializeField] bool _isToggled = false;
    private GameObject _light;

    private void Start()
    {
        _light = transform.parent.GetChild(1).gameObject;

        _light.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");

        if (collision.CompareTag("Light"))
        {
            _isToggled = true;
            ApplyStateAndRotate(collision.gameObject);
        }

    }

    private void ApplyStateAndRotate(GameObject lightSource)
    {
        Debug.Log("Apply state & rotate");
        
        Vector3 direction = lightSource.transform.position - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);

        _light.transform.eulerAngles = new Vector3(0, 0, targetAngle - 90);


        if (_isToggled)
            _light.SetActive(true);
        else
            _light.SetActive(false);
    }
}
