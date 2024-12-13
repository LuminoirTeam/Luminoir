using UnityEngine;

public class MonsterContainer : MonoBehaviour
{
    public bool containMonster;
    public bool isShadow;

    public GameObject shadowMonsterPrefab;
    public GameObject lightMonsterPrefab;

    public GameObject monsterSpawn;

    public void Start()
    {
        if (containMonster)
        {
            if (isShadow)
            {
                Instantiate(shadowMonsterPrefab, monsterSpawn.transform);
            }
            else
            {
                Instantiate(lightMonsterPrefab, monsterSpawn.transform);
            }
        }
    }
}
