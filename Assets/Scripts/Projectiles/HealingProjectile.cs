using UnityEngine;

public class HealingProjectile : Projectile
{
    private Rigidbody2D rb;

    private float deceleration = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        maxLife = 20;
    }

    private void FixedUpdate() => rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPlayer)
        {
            IHealable player = collision.GetComponentInParent<IHealable>();
            player.Heal(power);
            ReturnToPool();
        }
        else if (collision.gameObject.tag == "Environment")
            rb.linearVelocity = Vector2.zero;
    }

}
