using UnityEngine;

public abstract class LU_PowerInteraction : MonoBehaviour
{
    [SerializeField] GameObject _lumis;
    [SerializeField] float _shadowMoveSpeed = 0.2f;

    Rigidbody2D _rb;

    public abstract void MoveTowards();

    public abstract void MoveAwayFrom();


}