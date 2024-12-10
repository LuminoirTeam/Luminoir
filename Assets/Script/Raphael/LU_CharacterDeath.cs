using UnityEngine;

public class LU_CharacterDeath : MonoBehaviour
{
    private Vector3 _spawnPos;

    private void Update()
    {
        CheckIfOutOfBonds();
    }
    private void Start()
    {
        _spawnPos = transform.position;
    }

    public void ReturnToSpawn()
    {
        transform.position = _spawnPos;
    }

    private void CheckIfOutOfBonds()
    {
        if (LU_CameraBehaviour.Left >= transform.position.x)
        {
            ReturnToSpawn();
            return;
        }
        if(LU_CameraBehaviour.Right <= transform.position.x)
        {
            ReturnToSpawn();
        }
    }

}
