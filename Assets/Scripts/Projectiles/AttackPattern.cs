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

    public abstract void Initialise();
    public abstract void Attack(Vector2 enemyPos, GameObject projectile);
}
