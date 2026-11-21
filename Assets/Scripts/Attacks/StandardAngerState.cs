using System.Collections.Generic;
using UnityEngine;

public class StandardAngerState : AngerState
{

    public override void EnterState(AngerStateManager anger)
    {
        projectileSpeed = 5f;
        availableAttackPatterns = new List<AttackPattern>()
        {   new SpiralAttack(anger.objectPooler, projectileSpeed),
            new FanAttack(anger.objectPooler, projectileSpeed),
            new TargetedAttack(anger.objectPooler, projectileSpeed, anger.player),
            new HealingAttack(anger.objectPooler)};
        currentAttackPattern = availableAttackPatterns[0];
        attackFrequency = 0.1f;
        switchFrequency = 2.5f;
    }

    public override void SwitchState(AngerStateManager anger)
    {

    }

    public override void UpdateState(AngerStateManager anger)
    {
        attackTime += Time.deltaTime;
        currentAttackPattern.attackInbetweenTimer += Time.deltaTime;

        if (!currentAttackPattern.isFinished)
        {
            if (attackTime >= attackFrequency)
            {
                attackTime = 0;
                currentAttackPattern.Attack(anger.transform);
            }
        }
        else
        {
            switchTime += Time.deltaTime;

            if (switchTime >= switchFrequency)
            {
                switchTime = 0;
                currentAttackPattern = availableAttackPatterns[Random.Range(0, availableAttackPatterns.Count)];
                currentAttackPattern.ResetAttack();
            }
        }


    }
}
