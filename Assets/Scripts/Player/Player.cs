using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystem_Actions playerInput;
    private Rigidbody2D playerRB;
    private Vector2 playerMovement;
    private ObjectPooler objectPooler;
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] private float projectileSpeed = 20f;
    private bool isFiring = false;
    private float attackTimer;
    private float attackTime = 0.2f;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        playerInput = new InputSystem_Actions();

        playerInput.Player.Move.performed += OnMove;
        playerInput.Player.Move.canceled += OnMove;
        playerInput.Player.Attack.started += OnAttack;
        playerInput.Player.Attack.canceled += OnAttack;
    }

    public void Initialise(ObjectPooler pooler)
    {
        objectPooler = pooler;
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        isFiring = context.started;
    }

    private void Attack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector2 lookingDirection = (mousePos - playerRB.position).normalized;
        Vector2 projectileVelocity = lookingDirection * projectileSpeed;

        GameObject newProjectile = objectPooler.GetFromPool(ProjectileList.Standard, playerRB.position);
        newProjectile.GetComponent<Rigidbody2D>().linearVelocity = projectileVelocity;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        playerMovement = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if (isFiring)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                attackTimer = 0;
                Attack();
            }
        }
    }

    void FixedUpdate()
    {
        playerRB.linearVelocity = playerMovement.normalized * playerSpeed;
    }

    void OnEnable()
    {
        playerInput.Player.Enable();
    }

    void OnDisable()
    {
        playerInput.Player.Disable();
    }

    void OnDestroy()
    {
        playerInput.Dispose();
    }
}
