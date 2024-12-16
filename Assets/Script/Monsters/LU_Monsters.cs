using System.Collections;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    private SpriteRenderer spriteRenderer;
    public bool isShadow;
    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_isAlive)
        {
            Death();
        }
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

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(explosionParticles, gameObject.transform);
    }
}
