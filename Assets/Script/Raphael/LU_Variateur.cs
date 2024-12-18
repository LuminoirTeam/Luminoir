using UnityEngine;

public class LU_Variateur : MonoBehaviour
{
    GameObject _lightSource;
    GameObject _lightAttractor;
    [SerializeField] Vector2 _minScale;
    [SerializeField] Vector2 _maxScale;
    [SerializeField] float _lightInteractionPower = 0.1f;
    [UnityEngine.Range(0f, 1f)] float percentage;
    public bool _retracting = false;
    public bool _dilating = false;

    void Start()
    {
        _lightSource = transform.parent.GetChild(1).GetChild(0).gameObject;
        _lightAttractor = _lightSource.transform.parent.GetChild(1).gameObject;
        //_lightSource.transform.localScale = new Vector3(_minScale.x, _minScale.y, 1);
    }

    public void RetractLight()
    {
        // ((input - min) * 100) / (max - min)
        //((percent * (max - min) / 100) + min
        //1-1 4-1
        float xToADD = (_lightSource.transform.localScale.x - _lightInteractionPower) - _minScale.x / _maxScale.x;
        xToADD = xToADD * Time.deltaTime;
        float yToADD = (_lightSource.transform.localScale.y + _lightInteractionPower) - _minScale.y / _maxScale.y;
        yToADD = yToADD * Time.deltaTime;
        _lightSource.transform.localScale += new Vector3(xToADD, yToADD, 1);
        _lightSource.transform.localScale = new Vector3(Mathf.Clamp(_lightSource.transform.localScale.x, _minScale.x, _maxScale.x), Mathf.Clamp(_lightSource.transform.localScale.y, _minScale.y, _maxScale.y), 1);
        //_lightAttractor.transform.position += new Vector3(0, (_lightInteractionPower * Time.deltaTime), 0);
    }
    public void DilateLight()
    {
        float xToADD = (_lightSource.transform.localScale.x - _lightInteractionPower) - _minScale.x / _maxScale.x;
        xToADD = xToADD * Time.deltaTime;
        float yToADD = (_lightSource.transform.localScale.y + _lightInteractionPower) - _minScale.y / _maxScale.y;
        yToADD = yToADD * Time.deltaTime;
        _lightSource.transform.localScale -= new Vector3(xToADD, yToADD, 1);
        _lightSource.transform.localScale = new Vector3(Mathf.Clamp(_lightSource.transform.localScale.x, _minScale.x, _maxScale.x), Mathf.Clamp(_lightSource.transform.localScale.y, _minScale.y, _maxScale.y), 1);
        //_lightAttractor.transform.position -= new Vector3(0, _lightInteractionPower, 0);
    }
}
