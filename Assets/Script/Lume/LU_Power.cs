using UnityEngine;

public abstract class LU_Power : MonoBehaviour
{
    [SerializeField] protected float _powerRadius = 0.5f;
    protected bool _inAir = false;

    public abstract void AttractElement();

    public abstract void RepelElement();
}
