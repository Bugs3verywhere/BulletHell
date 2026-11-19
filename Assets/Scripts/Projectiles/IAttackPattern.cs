using UnityEngine;

public interface IAttackPattern
{
    public void Attack(Vector2 enemyPos, GameObject projectile, ObjectPooler objectPool);
}
