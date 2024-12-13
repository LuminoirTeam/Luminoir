using UnityEngine;

public class LU_Inverseur : MonoBehaviour
{
    string _lightTag = "Light";
    string _shadowTag = "Shadow";
    GameObject _createdLight;
    GameObject _createdLightAttractor;
    PolygonCollider2D _lightCollider;
    GameObject _createdShadow;

    private void Start()
    {
        _createdLight = transform.parent.GetChild(0).gameObject;
        _createdLightAttractor = _createdLight.transform.GetChild(1).gameObject;
        _createdShadow = transform.parent.GetChild(1).gameObject;
        Physics2D.IgnoreCollision(_createdShadow.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>(), true);
        Physics2D.IgnoreCollision(_createdLight.transform.GetChild(0).GetComponent<PolygonCollider2D>(), GetComponent<CircleCollider2D>(), true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_lightTag))
        {
            Vector3 attractorPos = collision.GetComponent<DistanceJoint2D>().attachedRigidbody.transform.position;
            Vector3 attractorDirection = (transform.position - attractorPos).normalized;
            _createdShadow.transform.position = transform.position + attractorDirection;
            _createdShadow.SetActive(true);
            return;

        }
        if (collision.CompareTag(_shadowTag))
        {
            Vector3 shadowPos = collision.transform.position;
            Vector3 shadowDirection = (transform.position - shadowPos).normalized;
            _createdLight.SetActive(true);

            _createdLightAttractor.transform.position = transform.position + shadowDirection;

            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _createdLight.SetActive(false);
        _createdShadow.SetActive(false);
    }
}
