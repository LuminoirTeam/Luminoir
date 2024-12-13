using System.Collections;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private SpriteRenderer spriteRenderer;
    private MonsterContainer monsterContainer;
    private bool isShadow;
    private bool isAlive;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        monsterContainer = GetComponentInParent<MonsterContainer>();
        isShadow = monsterContainer.isShadow;

        if (!isAlive)
        {
            Death();
        }
    }

    private void Death()
    {
        spriteRenderer = null;
        Instantiate(explosionParticles);
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isShadow && other.CompareTag("Shadow"))
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        if (!isShadow && other.CompareTag("Light"))
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }
}
