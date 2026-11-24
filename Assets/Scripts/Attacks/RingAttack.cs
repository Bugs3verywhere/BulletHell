using UnityEngine;
using System.Collections.Generic;

public class RingAttack : AttackPattern
{
    public RingAttack(ObjectPooler objectPool, float projectileSpeed, float attackInbetweenTime)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.Ring;

        curProjectile = ProjectileList.Standard;

        attacks = 120;
        attackDirections = 12;

        this.attackInbetweenTime = attackInbetweenTime;

        angle = 10;
        rotation = 10;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks && attackInbetweenTimer >= attackInbetweenTime)
        {
            angle += rotation;
            attackInbetweenTimer = 0f;

            for (int i = 0; i < attackDirections; i++)
            {
                vectorX = Mathf.Cos(angle * Mathf.Deg2Rad) * projectileSpeed;
                vectorY = Mathf.Sin(angle * Mathf.Deg2Rad) * projectileSpeed;

                angle += 360 / attackDirections;
                GameObject newProjectile = objectPool.GetFromPool(curProjectile, enemyPos.position);
                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
                rb.linearVelocity = new Vector2(vectorX, vectorY);
                attacksPerformed++;
            }

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
