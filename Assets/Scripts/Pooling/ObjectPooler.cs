using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    private Dictionary<ProjectileList, ProjectileFactory> factories;
    private Dictionary<ProjectileList, Stack<GameObject>> availableProjectiles;

    public ObjectPooler(Dictionary<ProjectileList, ProjectileFactory> factories, int initialPoolSize)
    {
        this.factories = factories;
        availableProjectiles = new Dictionary<ProjectileList, Stack<GameObject>>();

        foreach (KeyValuePair<ProjectileList, ProjectileFactory> entry in factories)
        {
            ProjectileList projectileType = entry.Key;
            ProjectileFactory factory = entry.Value;

            availableProjectiles[projectileType] = new Stack<GameObject>();

            for (int i = 0; i < initialPoolSize; i++)
            {
                availableProjectiles[projectileType].Push(factory.Create());
            }
        }
    }

    public GameObject GetFromPool(ProjectileList projectileType, Vector2 position)
    {
        Stack<GameObject> gettableObjects = availableProjectiles[projectileType];

        GameObject newProjectile;
        if (gettableObjects.Count > 0)
        {
            newProjectile = gettableObjects.Pop();
        }
        else
        {
            newProjectile = factories[projectileType].Create();
        }

        newProjectile.transform.position = position;
        newProjectile.GetComponent<Projectile>().InitialiseReturn(() => ReturnProjectile(projectileType, newProjectile));
        newProjectile.SetActive(true);
        return newProjectile;
    }

    public void ReturnProjectile(ProjectileList projectileType, GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        availableProjectiles[projectileType].Push(returnedBullet);
    }
}
