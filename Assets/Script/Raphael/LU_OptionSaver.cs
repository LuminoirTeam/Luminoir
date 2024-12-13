using UnityEngine;

public class LU_OptionSaver : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
