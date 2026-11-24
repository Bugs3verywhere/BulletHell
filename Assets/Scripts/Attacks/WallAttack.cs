using UnityEngine;

public class WallAttack : AttackPattern
{
    public WallAttack(ObjectPooler objectPool, float projectileSpeed)
    {
        this.objectPool = objectPool;
        this.projectileSpeed = projectileSpeed;

        PatternType = AttackPatternList.Wall;

        curProjectile = ProjectileList.Standard;

        attacks = 256;
        attackDirections = 4;

        angle = 45;
    }

    public override void Attack(Transform enemyPos)
    {
        if (attacksPerformed < attacks)
        {
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
