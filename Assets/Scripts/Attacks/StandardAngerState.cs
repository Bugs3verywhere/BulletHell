using System.Collections.Generic;
using System.Diagnostics;

public class StandardAngerState : AngerState
{
    protected override void InitialiseState(AngerStateManager anger, Health enemyHealth)
    {
        projectileSpeed = 5f;

        availableAttackPatterns = new List<AttackPattern>()
        {
            new SpiralAttack(anger.objectPooler, projectileSpeed),
            new FanAttack(anger.objectPooler, projectileSpeed, 0.5f),
            new TargetedAttack(anger.objectPooler, projectileSpeed, anger.player),
            new HealingAttack(anger.objectPooler)
        };

        attackDuration = 0.1f;
        teleDuration = 1.5f;
        restDuration = 1.5f;
        switchDuration = 2f;

        healthGate = 990;
    }

    public override void SwitchState(AngerStateManager anger)
    {
        anger.SwitchState(anger.angryState);
    }
}
