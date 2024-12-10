using UnityEngine;

public class LU_ToggleLightbulb : MonoBehaviour
{
    [SerializeField] bool _isToggled = false;
    private GameObject _fixlight;

    private void Start()
    {
        _fixlight = transform.parent.GetChild(1).gameObject;

        CheckAndSwapState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
            _isToggled = true;

        if (collision.CompareTag("Shadow"))
            _isToggled = false;

        CheckAndSwapState();
    }

    private void CheckAndSwapState()
    {
        if (_isToggled)
            _fixlight.SetActive(true);
        else
            _fixlight.SetActive(false);
    }
}
