using UnityEngine;

public class GameController : MonoBehaviour
{
    private AttackManager attackManager;

    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject homing;
    [SerializeField] private GameObject healing;
    private ObjectPooler standardPool;
    private ObjectPooler homingPool;
    private ObjectPooler healingPool;
    private ProjectileFactory standardFactory;
    private ProjectileFactory homingFactory;
    private ProjectileFactory healingFactory;
    private GameObject player;
    private GameObject enemy;

    void Start()
    {
        standardFactory = new StandardProjectileFactory(standard, enemy.transform);
        homingFactory = new HomingProjectileFactory(homing, enemy.transform, player.transform);
        healingFactory = new HealingProjectileFactory(healing, enemy.transform);

        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }
}
