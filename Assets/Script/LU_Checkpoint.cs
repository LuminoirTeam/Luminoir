using UnityEngine;

public class LU_Checkpoint : MonoBehaviour
{
    [HideInInspector]
    public Vector3 lumisSpawn;

    [HideInInspector]
    public Vector3 noctisSpawn;


    private void Start()
    {
        lumisSpawn=transform.GetChild(0).position;
        noctisSpawn=transform.GetChild(1).position;
    }

    public GameObject currentCharacterInCheckpoint;
}
