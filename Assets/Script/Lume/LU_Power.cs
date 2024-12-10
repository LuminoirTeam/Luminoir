using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class LU_Power : MonoBehaviour
{
    [SerializeField] protected float _powerRadius = 0.5f;

    public abstract void AttractElement();

    public abstract void RepelElement();

    public void KillCharacter()
    {
        GetComponent<LU_CharacterDeath>().ReturnToSpawn();
    }
}
