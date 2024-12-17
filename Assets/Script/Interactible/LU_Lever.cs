using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private List<GameObject> doorList;
    public Animator leverAnimator;

    private void Start()
    {
        leverAnimator = GetComponentInChildren<Animator>();
    }

    public void OpenDoor()
    {
        {
            foreach (GameObject door in doorList)
            {
                door.GetComponentInChildren<DoorOpening>().OpenDoor();
                leverAnimator.SetBool("Activated", true);
            }
        }
    }
}
