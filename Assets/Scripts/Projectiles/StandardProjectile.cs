using UnityEngine;

public class StandardProjectile : Projectile
{
    void Awake()
    {
        maxLife = 5f;
    }

    public override void InitialiseProjectile(Transform playerPos)
    {
        throw new System.NotImplementedException();
    }
}
