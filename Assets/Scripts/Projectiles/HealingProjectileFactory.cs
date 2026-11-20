using UnityEngine;

public class HealingProjectileFactory : ProjectileFactory
{
    private GameObject prefab;

    public HealingProjectileFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public override GameObject Create()
    {
        GameObject newProjectile = Object.Instantiate(prefab);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
