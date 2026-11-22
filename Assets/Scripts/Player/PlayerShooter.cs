using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform playerPos;
    private float projectileSpeed = 20f;
    private float fireSpeed = 0.2f;
    private float fireTimer;

    private ObjectPooler objectPooler;

    public void Initialise(ObjectPooler pooler) => objectPooler = pooler;

    private void Update()
    {
        if (player.isFiring)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireSpeed)
            {
                fireTimer = 0;
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                Vector2 lookingDirection = (mousePos - (Vector2)playerPos.position).normalized;
                Vector2 projectileVelocity = lookingDirection * projectileSpeed;

                GameObject newProjectile = objectPooler.GetFromPool(ProjectileList.StandardPlayer, playerPos.position);
                newProjectile.GetComponent<Projectile>().isPlayer = true;
                newProjectile.GetComponent<Rigidbody2D>().linearVelocity = projectileVelocity;
            }

        }
    }
}
