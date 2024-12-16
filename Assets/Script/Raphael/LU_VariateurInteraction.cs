using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LU_VariateurInteraction : MonoBehaviour
{
    float _powerRadius=0.5f;
    List<Collider2D> colliderFound;
    private void Start()
    {
        _powerRadius= GetComponent<LU_PowerNoctis>().GetPowerRadius();
        colliderFound = new List<Collider2D>();
    }
    public void RetractVariateur(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            colliderFound.Clear();
            colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 10).ToList();
            foreach (Collider2D collider in colliderFound)
            {
                collider.gameObject.GetComponent<LU_Variateur>()._retracting = true;
            }
        }
        if (context.canceled)
        {
            foreach (Collider2D collider in colliderFound)
            {
                collider.gameObject.GetComponent<LU_Variateur>()._retracting = false;
            }
        }
    }

    public void DilateVariateur(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            colliderFound.Clear();
            colliderFound = Physics2D.OverlapCircleAll(transform.position, _powerRadius, 1 << 10).ToList();
            foreach (Collider2D collider in colliderFound)
            {
                collider.gameObject.GetComponent<LU_Variateur>()._dilating = true;
            }
        }
        if (context.canceled)
        {
            foreach (Collider2D collider in colliderFound)
            {
                collider.gameObject.GetComponent<LU_Variateur>()._dilating = false;
            }
        }
    }
}
