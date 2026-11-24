using UnityEngine;
using System.Collections.Generic;

public class RandomAttack : AttackPattern
{
    public RandomAttack(ObjectPooler objectPool, float projectileSpeed)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.Random;

        availableProjectiles = new List<ProjectileList> { ProjectileList.Standard, ProjectileList.Homing };
        curProjectile = ProjectileList.Standard;

        attacks = 72;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = Mathf.Cos(Random.Range(0, 360) * Mathf.Deg2Rad) * projectileSpeed;
            vectorY = Mathf.Sin(Random.Range(0, 360) * Mathf.Deg2Rad) * projectileSpeed;

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
        curProjectile = Random.value < 0.7f ? availableProjectiles[0] : availableProjectiles[1];
    }
}
