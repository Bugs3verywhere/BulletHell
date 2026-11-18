using UnityEngine;

public interface IAttackPattern
{
    public void Initialise();
    public void Attack(Vector2 enemyPos, GameObject projectile);
}
