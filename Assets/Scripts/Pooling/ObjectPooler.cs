using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    private List<GameObject> availableProjectiles;

    private ProjectileFactory projectileFactory;
    private Transform playerTransform;
    private GameObject projectile;
    [SerializeField] private int initialPoolSize;

    public ObjectPooler(ProjectileFactory projectileFactory, GameObject projectile, int initialPoolSize, Transform playerTransform)
    {
        this.projectileFactory = projectileFactory;
        this.projectile = projectile;
        this.initialPoolSize = initialPoolSize;
        this.playerTransform = playerTransform;

        availableProjectiles = new List<GameObject>();

        InitialPool();
    }

    private void InitialPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject pooledObject = projectileFactory.Create(projectile, playerTransform);
            availableProjectiles.Add(pooledObject);
        }
    }
}
