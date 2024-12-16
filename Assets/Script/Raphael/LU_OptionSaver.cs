using UnityEngine;

public class LU_OptionSaver : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<LU_Audio>().DetachFromMenu();
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
