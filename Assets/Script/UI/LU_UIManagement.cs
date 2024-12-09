using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LU_UIManagement : MonoBehaviour
{
    public TMP_Text CountdownText;
    public TMP_Text CountupText;
    public float CountdownTime = 300f; // 5 minutes in seconds
    private float _countupTime = 0f;
    private bool _countdownActive = true;

    void Start()
    {
        UpdateCountdownText();
        UpdateCountupText();
    }

    void Update()
    {
        if (_countdownActive)
        {
            CountdownTime -= Time.deltaTime;
            if (CountdownTime <= 0)
            {
                CountdownTime = 0;
                _countdownActive = false;
            }
            UpdateCountdownText();
        }

        _countupTime += Time.deltaTime;
        UpdateCountupText();
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(CountdownTime / 60);
        int seconds = Mathf.FloorToInt(CountdownTime % 60);
        CountdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateCountupText()
    {
        int minutes = Mathf.FloorToInt(_countupTime / 60);
        int seconds = Mathf.FloorToInt(_countupTime % 60);
        CountupText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
