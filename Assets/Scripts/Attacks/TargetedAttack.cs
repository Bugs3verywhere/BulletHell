using System.Collections.Generic;
using UnityEngine;

public class TargetedAttack : AttackPattern
{

    private Transform playerPos;

    public TargetedAttack(ObjectPooler objectPool, float projectileSpeed, Transform playerPos)
    {
        this.objectPool = objectPool;
        this.playerPos = playerPos;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.Targeted;

        availableProjectiles = new List<ProjectileList> { ProjectileList.Standard, ProjectileList.Homing };
        curProjectile = ProjectileList.Standard;

        attacks = 72;
        attackDirections = 5;

        rotation = 15;

        attackInbetweenTime = 0.4f;

        isFinished = false;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks && attackInbetweenTimer >= attackInbetweenTime)
        {
            attackInbetweenTimer = 0;

            for (int i = 0; i < attackDirections; i++)
            {
                Vector2 playerDirection = playerPos.position - enemyPos.position;

                float offsetDegrees = (i - (attackDirections - 1) / 2f) * rotation;
                float aimDirection = Mathf.Atan2(playerDirection.y, playerDirection.x) + offsetDegrees * Mathf.Deg2Rad;

                vectorX = Mathf.Cos(aimDirection) * projectileSpeed;
                vectorY = Mathf.Sin(aimDirection) * projectileSpeed;

                GameObject newProjectile = objectPool.GetFromPool(curProjectile, enemyPos.position);
                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
                rb.linearVelocity = new Vector2(vectorX, vectorY);
                attacksPerformed++;

                if (attacksPerformed >= attacks)
                    isFinished = true;
            }
        }
    }

    public override void ResetAttack()
    {
        attacksPerformed = 0;
        isFinished = false;
        curProjectile = Random.value < 0.7f ? availableProjectiles[0] : availableProjectiles[1];
    }
}
