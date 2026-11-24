using System.Collections.Generic;
using UnityEngine;

public class DoubleSpiralAttack : AttackPattern
{
    public DoubleSpiralAttack(ObjectPooler objectPool, float projectileSpeed)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.DoubleSpiral;

        availableProjectiles = new List<ProjectileList> { ProjectileList.Standard, ProjectileList.Homing };
        curProjectile = ProjectileList.Standard;

        attacks = 48;

        angle = 10;
        rotation = 20;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = Mathf.Cos(angle * Mathf.Deg2Rad) * projectileSpeed;
            vectorY = Mathf.Sin(angle * Mathf.Deg2Rad) * projectileSpeed;

            angle += rotation;
            GameObject newProjectile1 = objectPool.GetFromPool(curProjectile, enemyPos.position);
            GameObject newProjectile2 = objectPool.GetFromPool(curProjectile, enemyPos.position);
            Rigidbody2D rb1 = newProjectile1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = newProjectile2.GetComponent<Rigidbody2D>();
            rb1.linearVelocity = new Vector2(vectorX, vectorY);
            rb2.linearVelocity = new Vector2(-vectorX, -vectorY);
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
