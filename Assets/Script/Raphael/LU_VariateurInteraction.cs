using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LU_VariateurInteraction : MonoBehaviour
{
    float _powerRadius = 0.5f;

    private void Start()
    {
        _powerRadius = GetComponent<LU_PowerNoctis>().GetPowerRadius();
        colliderFound = new List<Collider2D>();
    }
    
}
