using System.Collections;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private SpriteRenderer spriteRenderer;
    private MonsterContainer monsterContainer;
    public bool isShadow;
    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        monsterContainer = GetComponentInParent<MonsterContainer>();
        isShadow = monsterContainer.isShadow;
    }

    private void Update()
    {
        _isAlive = false;

        if (!_isAlive)
        {
            Death();
        }
    }

    private void Death()
    {
        spriteRenderer = null;
        Instantiate(explosionParticles);
        Destroy(explosionParticles, 5);
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
            _isAlive = true;
        }

        if (!isShadow && other.CompareTag("Light"))
        {
            _isAlive = true;
        }
    }
}
