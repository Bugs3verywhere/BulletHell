using System.Collections.Generic;

public class StandardAngerState : AngerState
{
    protected override void InitialiseState(AngerStateManager anger)
    {
        availableAttackPatterns = new List<AttackPattern>()
        {
            new SpiralAttack(anger.objectPooler, projectileSpeed),
            new FanAttack(anger.objectPooler, projectileSpeed),
            new TargetedAttack(anger.objectPooler, projectileSpeed, anger.player),
            new HealingAttack(anger.objectPooler)
        };

        projectileSpeed = 5f;

        attackDuration = 0.1f;
        teleDuration = 1.5f;
        restDuration = 1.5f;
    }

    public override void SwitchState(AngerStateManager anger)
    {

    }
}
