using System.Collections.Generic;

public class AngryAngerState : AngerState
{
    protected override void InitialiseState(AngerStateManager anger, Health enemyHealth)
    {
        projectileSpeed = 7.5f;

        availableAttackPatterns = new List<AttackPattern>()
        {
            new FanAttack(anger.objectPooler, projectileSpeed, 0.25f),
            new DoubleSpiralAttack(anger.objectPooler, projectileSpeed),
            new HealingAttack(anger.objectPooler),
            new WallAttack(anger.objectPooler, projectileSpeed)
        };

        attackDuration = 0.1f;
        teleDuration = 1.5f;
        restDuration = 1.5f;
        switchDuration = 5f;

        healthGate = 250;
    }

    public override void SwitchState(AngerStateManager anger)
    {

    }
}
