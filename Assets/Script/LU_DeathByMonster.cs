using UnityEngine;

public class LU_DeathByMonster : MonoBehaviour
{
    public bool isNoctis;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightMonster") && isNoctis)
        {
            GetComponent<LU_CharacterController>().ReturnToSpawn();
        }
        else if (collision.gameObject.CompareTag("ShadowMonster") && !isNoctis)
        {
            GetComponent<LU_CharacterController>().ReturnToSpawn();
        }
    }
}