using System.Collections.Generic;
using UnityEngine;

public abstract class AngerState
{
    protected List<AttackPattern> availableAttackPatterns { get; set; }
    protected AttackPattern currentAttackPattern;
    protected AttackPattern spiralAttack;
    protected ObjectPooler objectPool;
    protected float projectileSpeed;
    protected float attackTime = 0f;
    protected float attackFrequency { get; set; }
    protected float switchTime = 0f;
    protected float switchFrequency { get; set; }

    public abstract void EnterState(AngerStateManager anger);
    public abstract void UpdateState(AngerStateManager anger);
    public abstract void SwitchState(AngerStateManager anger);

}
