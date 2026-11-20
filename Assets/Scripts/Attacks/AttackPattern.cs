using UnityEngine;

public abstract class AttackPattern
{
    protected int attacksPerformed;
    protected int attacks;
    protected float angle;
    protected float rotation;
    protected float vectorX;
    protected float vectorY;
    protected float projectileSpeed;
    public bool isFinished;
    protected ProjectileList currentProjectile;
    protected ObjectPooler objectPool;

    public abstract void Attack(Transform enemyPos, ProjectileList projectileType);
}
