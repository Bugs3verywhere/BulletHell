using System;
using UnityEngine;

public class HomingProjectile : Projectile
{
    private Rigidbody2D rb;
    private GameObject homingProjectile;
    private Transform playerPos;
    private float maxSpeed = 6f;
    private float turnAcceleration = 2f;
    private float rotateSpeed = 360f;

    private void Awake()
    {
        homingProjectile = gameObject;
        rb = homingProjectile.GetComponent<Rigidbody2D>();
        maxLife = 10f;
    }

    public override void InitialiseProjectile(Transform playerTransform)
    {
        playerPos = playerTransform;
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > 8f)
        {
            SpriteRenderer projectileSprite = gameObject.GetComponent<SpriteRenderer>();
            projectileSprite.color = new Color(1, 1, 1, maxLife % lifeTimer);
        }

        if (lifeTimer >= maxLife)
            ReturnToPool();

        Vector2 playerDirection = ((Vector2)playerPos.position - rb.position).normalized;

        rb.linearVelocity += playerDirection * turnAcceleration * Time.fixedDeltaTime;
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);

        float playerRotation = Mathf.Atan2(playerDirection.x, playerDirection.y) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(Mathf.MoveTowardsAngle(rb.rotation, playerRotation, rotateSpeed * Time.fixedDeltaTime));
    }
}
