using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AngerStateManager angerManager;

    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject homing;
    [SerializeField] private GameObject healing;
    [SerializeField] private GameObject player;
    private Dictionary<ProjectileList, ProjectileFactory> factories;
    private ObjectPooler objectPooler;

    void Start()
    {
        factories = new Dictionary<ProjectileList, ProjectileFactory> {
            { ProjectileList.Standard, new StandardProjectileFactory(standard) },
            { ProjectileList.Homing, new HomingProjectileFactory(homing, player.transform) },
            { ProjectileList.Healing, new HealingProjectileFactory(healing) } };

        objectPooler = new ObjectPooler(factories, 128);
        angerManager.Initialise(objectPooler);
    }
}
