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
                GameObject shadowClone = Instantiate(shadowMonsterPrefab, gameObject.transform);
                shadowClone.transform.position = monsterSpawn.transform.position;
            }
            else
            {
                GameObject lightClone = Instantiate(lightMonsterPrefab, gameObject.transform);
                lightClone.transform.position = monsterSpawn.transform.position;
            }
        }
    }
}
