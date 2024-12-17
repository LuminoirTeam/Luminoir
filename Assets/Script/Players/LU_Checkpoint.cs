using UnityEngine;

public class LU_Checkpoint : MonoBehaviour
{
    [HideInInspector]
    public Vector3 lumisSpawn;

    [HideInInspector]
    public Vector3 noctisSpawn;

    [HideInInspector]
    public ParticleSystem _activationParticles;


    private void Start()
    {
        _activationParticles = transform.GetChild(2).GetComponent<ParticleSystem>();
        
        lumisSpawn = transform.GetChild(0).position;
        noctisSpawn = transform.GetChild(1).position;
    }

    public GameObject currentCharacterInCheckpoint;
}
