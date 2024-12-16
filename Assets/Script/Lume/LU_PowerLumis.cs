using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LU_PowerLumis : LU_Power //Lumis interacts with SHADOW
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    public override void Grappling()
    {
        Collider2D colliderFound = Physics2D.OverlapCircle(transform.position, _powerRadius, 1 << 9);
        if (colliderFound != null)
        {
            rb.AddForce(colliderFound.transform.position - transform.position.normalized, ForceMode2D.Impulse);
        }
    }
    public override void AttractElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 9).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_ShadowReactToPower>().MoveTowards();
        }
    }

    public override void RepelElement()
    {
        List<Collider2D> colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 9).ToList();
        foreach (Collider2D collider in colliderFound)
        {
            collider.gameObject.GetComponent<LU_ShadowReactToPower>().MoveAwayFrom();
        }
    }

}
