using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public virtual void Idle() { }

    public virtual void Walk() { }
}