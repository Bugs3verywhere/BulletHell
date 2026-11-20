using UnityEngine;

public class SpiralAttack : AttackPattern
{


    public SpiralAttack(ObjectPooler objectPool, float projectileSpeed)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        attacksPerformed = 0;
        attacks = 36;
        angle = 10;
        rotation = 10;
        isFinished = false;
    }

    public override void Attack(Transform enemyPos, ProjectileList projectileType)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = 0;
            vectorY = 0;

            vectorX = Mathf.Cos(angle * Mathf.Deg2Rad) * projectileSpeed;
            vectorY = Mathf.Sin(angle * Mathf.Deg2Rad) * projectileSpeed;

            angle += rotation;
            GameObject newProjectile = objectPool.GetFromPool(projectileType, enemyPos.position);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(vectorX, vectorY);
            attacksPerformed++;
        }
        else
            isFinished = true;
    }
}
