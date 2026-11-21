using NUnit.Framework.Interfaces;
using UnityEngine;

public class HealingProjectile : StandardProjectile
{
    private GameObject healingProjectile;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = healingProjectile.GetComponent<Rigidbody2D>();
        maxLife = 20;
    }
    private void Update()
    {
        rb.linearVelocity -= new Vector2(Time.fixedDeltaTime, Time.fixedDeltaTime);
    }
}
