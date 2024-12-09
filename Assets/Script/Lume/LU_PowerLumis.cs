using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LU_PowerLumis : LU_Power //Lumis interacts with SHADOW
{
    public override void AttractElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_ShadowReactToPower>().MoveTowardsLumis();
        }
    }

    public override void RepelElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 8).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_ShadowReactToPower>().MoveAwayFromLumis();
        }
    }
}
