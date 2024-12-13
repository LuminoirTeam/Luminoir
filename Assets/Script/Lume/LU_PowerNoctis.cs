using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LU_PowerNoctis : LU_Power //Noctis interacts with LIGHT
{
    public override void AttractElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_LightReactToPower>().MoveTowards();
        }
    }

    public override void RepelElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_LightReactToPower>().MoveAwayFrom();
        }
    }
    public float GetPowerRadius()
    {
        return _powerRadius;
    }
}
