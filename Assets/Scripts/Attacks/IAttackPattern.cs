using UnityEngine;

public interface IAttackPattern
{
    public void Attack(Transform enemyPos, GameObject projectile);
}
