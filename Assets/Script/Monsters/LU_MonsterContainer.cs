using UnityEngine;

public class MonsterContainer : MonoBehaviour
{
    public bool containMonster;
    public bool isShadow;

    public GameObject shadowMonsterPrefab;
    public GameObject lightMonsterPrefab;

    public Transform monsterSpawn;

    public void Start()
    {
        if (containMonster)
        {
            if (isShadow)
            {
                Instantiate(shadowMonsterPrefab);
                shadowMonsterPrefab.transform.position = monsterSpawn.position;
            }
            else
            {
                Instantiate(lightMonsterPrefab, monsterSpawn);
                lightMonsterPrefab.transform.position = monsterSpawn.position;
            }
        }
    }
}
