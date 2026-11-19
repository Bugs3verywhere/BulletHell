using UnityEngine;

public class HomingProjectileFactory : ProjectileFactory
{
    private Transform transform;
    private Transform playerTransform;

    public HomingProjectileFactory(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    public override GameObject Create(GameObject prefab, Transform playerTransform)
    {
        GameObject newProjectile = Object.Instantiate(prefab);
        newProjectile.GetComponent<HomingProjectile>();
        HomingProjectile homingProjectile = newProjectile.GetComponent<HomingProjectile>();
        homingProjectile.Initialise(playerTransform);
        newProjectile.SetActive(true);
        return newProjectile;
    }
}
