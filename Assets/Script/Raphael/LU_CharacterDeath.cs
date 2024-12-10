using UnityEngine;

public class LU_CharacterDeath : MonoBehaviour
{
    private Vector3 _spawnPos;

    private void Start()
    {
        _spawnPos = transform.position;
    }

    public void ReturnToSpawn()
    {
        transform.position = _spawnPos;
    }



}
