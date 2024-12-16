using UnityEngine;

public class LU_ElementReceptor : MonoBehaviour
{
    [SerializeField] private bool isShadow;
    [SerializeField] private bool isActivated;
    [SerializeField] private GameObject door;

    private void Update()
    {
        if (isActivated)
        {
             door.GetComponentInChildren<DoorOpening>().OpenDoor();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isActivated)
        {
            if (!isShadow)
            {
                if (other.CompareTag("Light"))
                {
                    door.GetComponentInChildren<DoorOpening>().OpenDoor();
                    isActivated = true;
                }
            }
            else
            {
                if (other.CompareTag("Shadow"))
                {
                    door.GetComponentInChildren<DoorOpening>().OpenDoor();
                    isActivated = true;
                }
            }
        }
    }
}
