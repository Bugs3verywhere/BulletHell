using System.Collections.Generic;
using UnityEngine;

public class HealingAttack : AttackPattern
{
    public HealingAttack(ObjectPooler objectPool)
    {
        this.objectPool = objectPool;

        PatternType = AttackPatternList.Healing;

        attacksPerformed = 0;
        attackInbetweenTime = 0.5f;
        attacks = 4;
        isFinished = false;

        curProjectile = ProjectileList.Healing;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks && attackInbetweenTimer >= attackInbetweenTime)
        {
            attackInbetweenTimer = 0f;
            vectorX = 0;
            vectorY = 0;

            vectorX = Random.Range(-8, 8);
            vectorY = Random.Range(-8, 8);

            GameObject newProjectile = objectPool.GetFromPool(curProjectile, enemyPos.position);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(vectorX, vectorY);
            attacksPerformed++;
            if (attacksPerformed >= attacks)
                isFinished = true;
        }
    }

    public override void ResetAttack()
    {
        attacksPerformed = 0;
        isFinished = false;
    }
}
