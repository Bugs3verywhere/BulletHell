using UnityEngine;

public class AttackManager
{
    private AttackPattern currentAttackPattern;
    private AttackPatternList availablePatterns;

    [SerializeField] private GameObject enemy;
    public Transform playerTransform;

    public GameObject standard;
    private ProjectileFactory standardFactory;
    private ObjectPooler standardPooler;

    public GameObject homing;
    private ProjectileFactory homingFactory;
    private ObjectPooler homingPooler;

    public AttackManager(Transform playerTransform, GameObject standard, GameObject homing)
    {
        this.playerTransform = playerTransform;
        homingFactory = new HomingProjectileFactory(playerTransform);
        homingPooler = new ObjectPooler(homingFactory, homing, 150, playerTransform);
        standardFactory = new StandardProjectileFactory();
        standardPooler = new ObjectPooler(standardFactory, standard, 150, playerTransform);
    }
}
