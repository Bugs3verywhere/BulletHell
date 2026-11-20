using UnityEngine;

public class HomingProjectileFactory : ProjectileFactory
{
    private Transform enemyPos;
    private Transform playerTransform;
    private GameObject prefab;

    public HomingProjectileFactory(GameObject prefab, Transform enemyPos, Transform playerTransform)
    {
        this.prefab = prefab;
        this.enemyPos = enemyPos;
        this.playerTransform = playerTransform;
    }

    public override GameObject Create()
    {
        GameObject newProjectile = Object.Instantiate(prefab, enemyPos.position, Quaternion.identity);
        newProjectile.GetComponent<HomingProjectile>();
        HomingProjectile homingProjectile = newProjectile.GetComponent<HomingProjectile>();
        homingProjectile.InitialiseProjectile(playerTransform);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
