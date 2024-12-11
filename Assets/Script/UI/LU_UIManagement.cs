using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LU_UIManagement : MonoBehaviour
{
    [Header("Canvas References")]
    [SerializeField] private Canvas _pauseCanvas; 
        //this is only used on the play scene, there won't be any bugs if it's unassigned in any other scene
    [Space]

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
        _isPaused = false;
        TogglePause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UIButton_MainMenu()
    {
        _isOnMainMenu = true;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnControllerPressPause()
    {
        if (!_isOnMainMenu)
        {

            if (!_isPaused)
                _isPaused = true;
            else
                _isPaused = false;

            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (_isPaused && _pauseCanvas)
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
