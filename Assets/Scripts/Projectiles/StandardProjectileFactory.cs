using UnityEngine;

public class StandardProjectileFactory : ProjectileFactory
{
    private GameObject prefab;
    private Transform enemyPos;

    public StandardProjectileFactory(GameObject prefab, Transform enemyPos)
    {
        this.prefab = prefab;
        this.enemyPos = enemyPos;
    }

    public override GameObject Create()
    {
        GameObject newProjectile = Object.Instantiate(prefab, enemyPos.position, Quaternion.identity);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
