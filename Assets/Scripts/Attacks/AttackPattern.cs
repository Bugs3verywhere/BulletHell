using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackPattern
{
    public AttackPatternList PatternType { get; protected set; }
    public ProjectileList CurrentProjectile => curProjectile;
    protected int attacksPerformed;
    protected int attacks;
    protected int attackDirections;
    protected float angle;
    protected float rotation;
    protected float vectorX;
    protected float vectorY;
    protected float projectileSpeed;
    public bool isFinished;
    public float attackInbetweenTimer = 0f;
    public float attackInbetweenTime;
    protected List<ProjectileList> availableProjectiles;
    protected ProjectileList curProjectile;
    protected ObjectPooler objectPool;

    public abstract void Attack(Transform enemyPos);
    public abstract void ResetAttack();
}
