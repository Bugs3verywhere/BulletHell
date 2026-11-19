using UnityEngine;

public abstract class ProjectileFactory
{
    public abstract GameObject Create(GameObject prefab, Transform playerTransform);
}
