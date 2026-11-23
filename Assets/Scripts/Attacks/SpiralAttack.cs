using System.Collections.Generic;
using UnityEngine;

public class SpiralAttack : AttackPattern
{
    public SpiralAttack(ObjectPooler objectPool, float projectileSpeed)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.Spiral;

        availableProjectiles = new List<ProjectileList> { ProjectileList.Standard, ProjectileList.Homing };
        curProjectile = ProjectileList.Standard;

        attacks = 48;

        angle = 10;
        rotation = 20;

        isFinished = false;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = Mathf.Cos(angle * Mathf.Deg2Rad) * projectileSpeed;
            vectorY = Mathf.Sin(angle * Mathf.Deg2Rad) * projectileSpeed;

            angle += rotation;
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
