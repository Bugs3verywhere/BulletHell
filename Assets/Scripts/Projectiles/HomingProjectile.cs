using System;
using UnityEngine;

public class HomingProjectile : Projectile
{
    private Rigidbody2D rb;
    private GameObject homingProjectile;
    private Transform playerPos;
    private float speed = 4f;

    private void Awake()
    {
        homingProjectile = gameObject;
        rb = homingProjectile.GetComponent<Rigidbody2D>();
    }

    public override void Initialise(Transform playerTransform)
    {
        playerPos = playerTransform;
    }

    private void Update()
    {
        Vector2 direction = (playerPos.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x);

        rb.linearVelocity = direction * speed;

        rb.MoveRotation((angle * Mathf.Rad2Deg) - 90f);
    }
}
