using UnityEngine;

public class PlayerProjectile : Projectile
{
    void Awake()
    {
        isPlayer = true;
        maxLife = 5f;
    }
}
