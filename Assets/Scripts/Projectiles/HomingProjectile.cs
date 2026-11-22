using UnityEngine;

public class HomingProjectile : Projectile
{
    private Rigidbody2D rb;
    private Transform playerPos;
    private float maxSpeed = 6f;
    private float turnAcceleration = 2f;
    private float rotateSpeed = 360f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        maxLife = 10f;
    }

    public void InitialiseProjectile(Transform playerTransform)
    {
        playerPos = playerTransform;
    }

    private void FixedUpdate()
    {

        Vector2 playerDirection = ((Vector2)playerPos.position - rb.position).normalized;

        rb.linearVelocity += playerDirection * turnAcceleration * Time.fixedDeltaTime;
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);

        float playerRotation = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(Mathf.MoveTowardsAngle(rb.rotation, playerRotation, rotateSpeed * Time.fixedDeltaTime));
    }
}
