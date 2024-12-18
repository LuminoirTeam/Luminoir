using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private List<GameObject> doorList;
    public Animator leverAnimator;
    [SerializeField] bool testLever=false;

    private void Start()
    {
        leverAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (testLever)
        {
            OpenDoor();
            this.enabled = false;
        }
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
