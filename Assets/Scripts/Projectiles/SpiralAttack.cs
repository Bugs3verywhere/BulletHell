using UnityEngine;

public class SpiralAttack : AttackPattern
{
    public override void Initialise()
    {
        attacksPerformed = 0;
        attacks = 36;
        angle = 10;
        rotation = 10;
        attackTime = 0.1f;
        attackTimer = 0;
        speed = 10;
    }

    public override void Attack(Vector2 enemyPos, GameObject projectile)
    {
        if (attacksPerformed < attacks)
        {
            vectorX = 0;
            vectorY = 0;
            attackTimer += Time.deltaTime;

            vectorX = Mathf.Cos(angle * Mathf.Deg2Rad) * speed;
            vectorY = Mathf.Sin(angle * Mathf.Deg2Rad) * speed;

            if (attackTimer >= attackTime)
            {
                angle += rotation;
                attackTimer = 0;
                GameObject newProjectile = Object.Instantiate(projectile, enemyPos, Quaternion.identity);
                Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
                rb.linearVelocity = new Vector2(vectorX, vectorY);
                attacksPerformed++;
            }
        }
    }
}
