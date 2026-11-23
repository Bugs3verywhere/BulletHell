using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    private InputSystem_Actions playerInput;

    private Rigidbody2D playerRB;

    private Vector2 playerMovement;

    public bool isFiring => playerInput.Player.Attack.IsPressed();

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        playerInput = new InputSystem_Actions();

        playerInput.Player.Move.performed += OnMove;
        playerInput.Player.Move.canceled += OnMove;
    }

    void OnMove(InputAction.CallbackContext context) => playerMovement = context.ReadValue<Vector2>();
    void FixedUpdate() => playerRB.linearVelocity = playerMovement.normalized * playerSpeed;
    void OnEnable() => playerInput.Player.Enable();
    void OnDisable() => playerInput.Player.Disable();
    void OnDestroy() => playerInput.Dispose();

}
