using UnityEngine;
using System;

public abstract class Projectile : MonoBehaviour
{
    protected float power;
    protected float maxLife;
    public float lifeTimer = 0f;
    private Action returnToPool;

    public abstract void InitialiseProjectile(Transform playerPos);

    public void InitialiseReturn(Action returnToPool)
    {
        this.returnToPool = returnToPool;
    }

    public void ReturnToPool()
    {
        returnToPool?.Invoke();
    }

}
