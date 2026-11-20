using System.Collections.Generic;
using UnityEngine;

public class StandardAngerState : AngerState
{

    public override void EnterState(AngerStateManager anger)
    {
        projectileSpeed = 5f;
        availableAttackPatterns = new List<AttackPattern>() { new SpiralAttack(anger.objectPooler, projectileSpeed) };
        currentAttackPattern = availableAttackPatterns[0];
        attackFrequency = 0.3f;
        switchFrequency = 5f;
    }

    public override void SwitchState(AngerStateManager anger)
    {

    }

    public override void UpdateState(AngerStateManager anger)
    {
        attackTime += Time.fixedDeltaTime;
        switchTime += Time.fixedDeltaTime;

        if (attackTime >= attackFrequency)
        {
            currentAttackPattern.Attack(anger.transform, ProjectileList.Standard);
        }

        if ((switchTime >= switchFrequency) && currentAttackPattern.isFinished)
        {
            int randomNum = Random.Range(0, availableAttackPatterns.Count);
            currentAttackPattern = availableAttackPatterns[randomNum];
        }

    }
}
