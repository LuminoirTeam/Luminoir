using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LU_HUDManager : MonoBehaviour
{
    [Header("Text References")]
    public TMP_Text CountdownText;
    public TMP_Text CountupText;

    [Header("UI Manager")]
    [SerializeField] private LU_UIManagement _uiManager; [Space]

    [Header("Timer")]
    public float CountdownTime = 300f; // 5 minutes in seconds

    private float _countupTime = 0f;
    public bool countdownActive = false;
    public GameObject defeatScreen;

    public void SetSpeedrunMod()
    {
        countdownActive = true;
    }

    void Start()
    {
        InitHUD();
        Time.timeScale = 1;

        LU_Audio.PlaySound(SoundType.musics, 0, 1);
    }

    void Update()
    {
        Loose();

        if (!_uiManager._isPaused)
        {
            if (countdownActive)
            {
                CountdownTime -= Time.deltaTime;
                if (CountdownTime <= 0)
                {
                    CountdownTime = 0;
                    countdownActive = false;
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
    }

    public void InitHUD()
    {
        _countupTime = 0f;

        UpdateCountdownText();
        UpdateCountupText();
    }

    private void Loose()
    {
        if (CountdownTime <= 0.0f)
        {
            defeatScreen.gameObject.SetActive(true);
        }
    }
}
