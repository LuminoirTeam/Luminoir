using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEditor;

public class LU_UIManagement : MonoBehaviour
{
    //Used to load next scene
    [SerializeField] int nextSceneBuildIndex;

    [Header("Canvas References")]
    [SerializeField] private GameObject _menuCanvas=null;
    [SerializeField] bool _hasPauseMenu=false;

        //this is only used on the play scene, there won't be any bugs if it's unassigned in any other scene
    [Space]

    [Header("Bools")]
    public bool _isPaused = false; //the HUD Manager needs this
    public bool _isOnMainMenu;

    private void Start()
    {
        if (_menuCanvas == null)
            return;

        if (SceneManager.GetActiveScene().name == "Main Menu")
            _isOnMainMenu = true;

        _isPaused = false;
        if (_hasPauseMenu)
        {
            TogglePause();
        }
    }

    public void UIButton_Start()
    {
        _isOnMainMenu = false;
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex).name);
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

    public void OnControllerPressPause(InputAction.CallbackContext context)
    {
        if (context.started)
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
    }

    private void TogglePause()
    {
        if (_isPaused && _menuCanvas)
        {
            _menuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _menuCanvas.gameObject.SetActive(false);
            _menuCanvas.transform.GetChild(1).gameObject.SetActive(false); // option menu
            Time.timeScale = 1;
        }
    }

}
