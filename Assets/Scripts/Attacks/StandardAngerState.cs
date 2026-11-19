using System.Collections.Generic;
using UnityEngine;

public class StandardAngerState : AngerState
{

    public override void EnterState(AngerStateManager anger)
    {
        availableAttackPatterns = new List<AttackPattern>() { };
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

        if (switchTime >= switchFrequency)
        {
            int randomNum = Random.Range(0, availableAttackPatterns.Count);
            currentAttackPattern = availableAttackPatterns[randomNum];
        }


    }
}
