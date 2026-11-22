using UnityEngine;

public class HomingProjectileFactory : ProjectileFactory
{
    private Transform playerTransform;
    private GameObject prefab;

    public HomingProjectileFactory(GameObject prefab, Transform playerTransform)
    {
        this.prefab = prefab;
        this.playerTransform = playerTransform;
    }

    public override GameObject Create()
    {
        GameObject newProjectile = Object.Instantiate(prefab);
        HomingProjectile homingProjectile = newProjectile.GetComponent<HomingProjectile>();
        homingProjectile.InitialiseProjectile(playerTransform);
        newProjectile.SetActive(false);
        return newProjectile;
    }
}
