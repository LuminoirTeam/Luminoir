using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LU_HUDManager : MonoBehaviour
{
    [Header("Text References")]
    public TMP_Text CountdownText;
    public TMP_Text CountupText;
    public TMP_Text EndCountText; [Space]

    [Header("UI Manager")]
    [SerializeField] private LU_UIManagement _uiManager; [Space]

    [Header("Timer")]
    public float CountdownTime = 300f; // 5 minutes in seconds

    private float _countupTime = 0f;
    private bool _countdownActive = true;

    void Start()
    {
        InitHUD();
    }

    void Update()
    {
        if (!_uiManager._isPaused)
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
        EndCountText.text = CountupText.text;
    }

    public void InitHUD()
    {
        CountdownTime = 300f; // 5 minutes in seconds
        _countupTime = 0f;
        _countdownActive = true;

        UpdateCountdownText();
        UpdateCountupText();
    }
}
