using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LU_PowerNoctis : LU_Power //Noctis interacts with LIGHT
{
    Rigidbody2D rb;
    LU_PlayAudioInQueue _audio;
    private void Start()
    {
        rb= transform.parent.GetComponent<Rigidbody2D>();
        _audio = transform.GetChild(4).GetComponent<LU_PlayAudioInQueue>();
    }
    //public override void Grappling()
    //{
    //    Collider2D colliderFound = Physics2D.OverlapCircle(transform.position, _powerRadius, 1 << 8);
    //    if (colliderFound != null)
    //    {
    //        rb.AddForce(colliderFound.transform.position - transform.position.normalized, ForceMode2D.Impulse);
    //    }

    //}
    public override void AttractElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            if(collider.TryGetComponent<LU_LightReactToPower>(out LU_LightReactToPower light))
            {
                light.MoveTowards();
                return;
            }
            if(collider.TryGetComponent<LU_Variateur>(out LU_Variateur variateur))
            {
                variateur.RetractLight();
                return;
            }
                
        }
    }

    public override void RepelElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            if (collider.TryGetComponent<LU_LightReactToPower>(out LU_LightReactToPower light))
            {
                light.MoveAwayFrom();
                return;
            }
            if (collider.TryGetComponent<LU_Variateur>(out LU_Variateur variateur))
            {
                variateur.DilateLight();
                return;
            }
        }
    }
    public float GetPowerRadius()
    {
        return _powerRadius;
    }


}
