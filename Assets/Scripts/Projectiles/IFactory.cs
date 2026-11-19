using UnityEngine;

public interface IFactory
{
    public abstract GameObject Create(GameObject prefab);
}
