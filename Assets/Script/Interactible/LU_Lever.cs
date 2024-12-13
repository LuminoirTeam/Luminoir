using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private List<GameObject> doorList;
    [SerializeField] private bool isActivated;

    private void Update()
    {
        if (isActivated)
        {
            foreach (GameObject door in doorList)
            {
                door.GetComponentInChildren<DoorOpening>().OpenDoor();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isActivated)
        {
            if(other.CompareTag("Player"))
            {
                foreach (GameObject door in doorList)
                {
                    door.GetComponentInChildren<DoorOpening>().OpenDoor();
                    isActivated = true;
                }
            }
        }
    }
}
