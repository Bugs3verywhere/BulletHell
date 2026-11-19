using System.Collections.Generic;
using UnityEngine;

public class AttackManager
{
    private AttackPattern currentAttackPattern;
    private List<AttackPattern> availablePatterns;

    [SerializeField] private GameObject enemy;
    public Transform playerTransform;

    public GameObject standard;
    private ProjectileFactory standardFactory;
    private ObjectPooler standardPooler;

    public GameObject homing;
    private ProjectileFactory homingFactory;
    private ObjectPooler homingPooler;

    public GameObject healing;
    private ProjectileFactory healingFactory;
    private ObjectPooler healingPooler;

    private AttackPattern currenAttackPattern;

    public AttackManager(Transform playerTransform, GameObject standard, GameObject homing, GameObject healing)
    {
        this.playerTransform = playerTransform;
        homingFactory = new HomingProjectileFactory(playerTransform);
        homingPooler = new ObjectPooler(homingFactory, homing, 128, playerTransform);
        standardFactory = new StandardProjectileFactory();
        standardPooler = new ObjectPooler(standardFactory, standard, 128, playerTransform);
        healingFactory = new HealingProjectileFactory();
        healingPooler = new ObjectPooler(healingFactory, healing, 20, playerTransform);
    }
}
