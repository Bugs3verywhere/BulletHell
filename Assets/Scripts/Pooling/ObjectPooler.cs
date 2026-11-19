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

    public GameObject GetFromPool()
    {
        GameObject newProjectile = null;

        for (int i = 0; i < availableProjectiles.Count; i++)
        {
            newProjectile = availableProjectiles[i];

            if (!newProjectile.activeSelf)
            {
                availableProjectiles.Remove(newProjectile);
                break;
            }

            newProjectile = null;
        }

        if (newProjectile == null)
        {
            newProjectile = projectileFactory.Create(projectile, playerTransform);
        }

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, 0);
        newProjectile.SetActive(true);

        return newProjectile;
    }

    public void ReturnProjectile(GameObject projectile)
    {
        if (!availableProjectiles.Contains(projectile))
        {
            projectile.SetActive(false);
            availableProjectiles.Add(projectile);
        }
    }
}
