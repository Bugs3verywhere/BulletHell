using UnityEngine;

public class StandardProjectile : Projectile
{
    void Awake()
    {
        maxLife = 5f;
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > 4f)
        {
            SpriteRenderer projectileSprite = gameObject.GetComponent<SpriteRenderer>();
            projectileSprite.color = new Color(1, 1, 1, maxLife % lifeTimer);
        }

        if (lifeTimer >= maxLife)
            ReturnToPool();
    }

    public override void InitialiseProjectile(Transform playerPos)
    {
        throw new System.NotImplementedException();
    }
}
