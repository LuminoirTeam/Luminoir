using UnityEngine;

public class LU_CollectibleGoToInventory : MonoBehaviour
{
    AudioSource audio;
    private void Start()
    {
        audio = transform.parent.GetChild(4).GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<LU_CharacterController>(out LU_CharacterController chacharacter))
        {
            transform.parent.parent.gameObject.GetComponent<LU_inventory>().inventory += 1;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
