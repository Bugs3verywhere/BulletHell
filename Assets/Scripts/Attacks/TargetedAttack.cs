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

        availableProjectiles = new List<ProjectileList> { ProjectileList.Standard, ProjectileList.Homing };
        attacksPerformed = 0;
        attacks = 48;
        isFinished = false;
        curProjectile = ProjectileList.Standard;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = 0;
            vectorY = 0;
            float xDelta;
            float yDelta;

            //Vector2 playerDirection = ((Vector2)playerPos.position - (Vector2)enemyPos.position).normalized;

            xDelta = playerPos.position.x - enemyPos.position.x;
            yDelta = playerPos.position.y - enemyPos.position.y;

            vectorX = Mathf.Cos(Mathf.Atan2(yDelta, xDelta)) * projectileSpeed;
            vectorY = Mathf.Sin(Mathf.Atan2(yDelta, xDelta)) * projectileSpeed;

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
