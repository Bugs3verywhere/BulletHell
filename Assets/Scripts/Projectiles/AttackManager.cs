using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private AttackPattern currentAttackPattern;
    private AttackPatternList availablePatterns;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject prefab;

    public void Start()
    {
        currentAttackPattern = new SpiralAttack();
        currentAttackPattern.Initialise();
    }

    public void Update()
    {
        Vector2 enemyPos = enemy.transform.position;
        currentAttackPattern.Attack(enemyPos, prefab);
    }
}
