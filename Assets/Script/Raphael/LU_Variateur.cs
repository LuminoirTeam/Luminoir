using UnityEngine;

public class LU_Variateur : MonoBehaviour
{

    string _lightTag = "Light";
    GameObject _lightSource;
    GameObject _lightAttractor;
    void Start()
    {
        _lightSource=transform.parent.GetChild(1).GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_lightTag))
        {
            Vector3 attractorPos = collision.GetComponent<DistanceJoint2D>().attachedRigidbody.transform.position;
            float attractorDistance=Vector3.Distance(transform.position, attractorPos);
            //_lightSource.transform.localScale=new Vector3(1*attr)
            Vector3 attractorDirection = (transform.position - attractorPos).normalized;
            _lightAttractor.transform.position = transform.position+attractorDirection;
            return;

        }
    }
}
