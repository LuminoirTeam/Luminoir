using UnityEngine;

public class LU_SetPlayer : MonoBehaviour
{
    public bool isNoctis;

    public GameObject lumisPrefab;
    public GameObject noctisPrefab;

    public LU_CharacterController characterController;

    public void SetActivePrefab()
    {
        if (isNoctis)
        {
            lumisPrefab.gameObject.SetActive(false);
            noctisPrefab.gameObject.SetActive(true);
            characterController.power = noctisPrefab.GetComponent<LU_PowerNoctis>();
        }
        else
        {
            lumisPrefab.gameObject.SetActive(true);
            noctisPrefab.gameObject.SetActive(false);
            characterController.power = lumisPrefab.GetComponent<LU_PowerLumis>();
        }
    }
}
