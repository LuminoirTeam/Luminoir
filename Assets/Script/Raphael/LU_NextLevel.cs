using UnityEngine;
using UnityEngine.SceneManagement;

public class LU_NextLevel : MonoBehaviour
{
    //Used to load next scene
    [SerializeField] int nextSceneBuildIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
