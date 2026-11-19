using UnityEngine;

public abstract class AttackPattern : IAttackPattern
{
    protected int attacksPerformed;
    protected int attacks;
    protected float angle;
    protected float rotation;
    protected float attackTime;
    protected float attackTimer;
    protected float vectorX;
    protected float vectorY;
    protected float speed;
    protected ProjectileList currentProjectile;
    protected ObjectPooler objectPool;

    public abstract void Attack(Transform enemyPos, GameObject projectile);
}
