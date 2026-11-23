using UnityEngine;

public class StandardProjectileFactory : ProjectileFactory
{
    private GameObject prefab;

    public StandardProjectileFactory(GameObject prefab) => this.prefab = prefab;

    public override GameObject Create()
    {
        GameObject newProjectile = Object.Instantiate(prefab);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
