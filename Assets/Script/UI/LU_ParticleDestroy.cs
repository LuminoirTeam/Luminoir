using System.Collections;
using UnityEngine;

public class LU_ParticleDestroy : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
