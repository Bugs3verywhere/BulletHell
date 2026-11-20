using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private AttackManager attackManager;

    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject homing;
    [SerializeField] private GameObject healing;
    private Dictionary<ProjectileList, ProjectileFactory> factories;
    private ObjectPooler objectPooler;
    private GameObject player;
    private GameObject enemy;

    void Start()
    {
        factories = new Dictionary<ProjectileList, ProjectileFactory> {
            { ProjectileList.Standard, new StandardProjectileFactory(standard, enemy.transform) },
            { ProjectileList.Homing, new HomingProjectileFactory(homing, enemy.transform, player.transform) },
            { ProjectileList.Healing, new HealingProjectileFactory(healing, enemy.transform) } };

        objectPooler = new ObjectPooler(factories, 128);
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }
}
