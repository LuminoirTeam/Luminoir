using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LU_UIManagement : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField] private Canvas _pauseCanvas; [Space]

    [Header("Bools")]
    public bool _isPaused = false; //the HUD Manager needs this
    public bool _isOnMainMenu;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
            _isOnMainMenu = true;

        _isPaused = false;
        TogglePause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnControllerPressPause();
        }
    }

    public void UIButton_Start()
    {
        Debug.Log("Start");

        _isOnMainMenu = false;
        SceneManager.LoadScene("Play");
    }

    public void UIButton_Quit()
    {
        Debug.Log("Quit");

        Application.Quit();
    }

    public void UIButton_Retry()
    {
        Debug.Log("Retry");
        _isPaused = false;
        TogglePause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UIButton_MainMenu()
    {
        Debug.Log("Main Menu");

        _isOnMainMenu = true;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnControllerPressPause()
    {
        if (!_isOnMainMenu)
        {
            Debug.Log("Controller Press Pause");

            if (!_isPaused)
                _isPaused = true;
            else
                _isPaused = false;

            TogglePause();
        }
        else
            Debug.Log("Cannot pause on Main Menu");
    }

    private void TogglePause()
    {
        Debug.Log("Toggle Pause");
        
        if (_isPaused)
        {
            _pauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _pauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
