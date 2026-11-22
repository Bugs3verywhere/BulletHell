using System.Collections.Generic;
using UnityEngine;

public abstract class AngerState
{
    private enum CurrentBehaviour { Telegraph, Attack, Rest }
    private CurrentBehaviour behaviour;

    protected List<AttackPattern> availableAttackPatterns;
    protected AttackPattern currentAttackPattern;

    protected float projectileSpeed;
    protected float teleDuration;
    protected float attackDuration;
    protected float restDuration;

    protected float teleTime;
    protected float attackTime;
    protected float restTime;

    protected abstract void InitialiseState(AngerStateManager anger);

    public void EnterState(AngerStateManager anger)
    {
        InitialiseState(anger);
        BeginAttack(anger, availableAttackPatterns[0]);
    }

    public void UpdateState(AngerStateManager anger)
    {
        currentAttackPattern.attackInbetweenTimer += Time.deltaTime;

        switch (behaviour)
        {
            case CurrentBehaviour.Telegraph:
                teleTime += Time.deltaTime;
                if (teleTime >= teleDuration)
                {
                    anger.TeleManager.TelegraphDeactivate();
                    attackTime = 0f;
                    behaviour = CurrentBehaviour.Attack;
                }
                break;

            case CurrentBehaviour.Attack:
                attackTime += Time.deltaTime;
                if (attackTime >= attackDuration)
                {
                    attackTime = 0f;
                    currentAttackPattern.Attack(anger.transform);
                }
                if (currentAttackPattern.isFinished)
                {
                    restTime = 0f;
                    behaviour = CurrentBehaviour.Rest;
                }
                break;

            case CurrentBehaviour.Rest:
                restTime += Time.deltaTime;
                if (restTime >= restDuration)
                {
                    BeginAttack(anger, availableAttackPatterns[Random.Range(0, availableAttackPatterns.Count)]);
                }
                break;
        }
    }

    private void BeginAttack(AngerStateManager anger, AttackPattern attackPattern)
    {
        currentAttackPattern = attackPattern;
        currentAttackPattern.ResetAttack();
        anger.TeleManager.TelegraphActivate(currentAttackPattern.PatternType, currentAttackPattern.CurrentProjectile);
        teleTime = 0f;
        behaviour = CurrentBehaviour.Telegraph;
    }

    public abstract void SwitchState(AngerStateManager anger);

}
