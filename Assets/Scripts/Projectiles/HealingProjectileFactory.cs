using UnityEngine;

public class HealingProjectileFactory : ProjectileFactory
{
    public override GameObject Create(GameObject prefab, Transform playerTransform)
    {
        GameObject newProjectile = Object.Instantiate(prefab);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
