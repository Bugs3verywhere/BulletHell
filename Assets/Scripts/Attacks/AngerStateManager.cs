using UnityEngine;

public class AngerStateManager : MonoBehaviour
{
    [SerializeField] private TelegraphManager teleManager;
    public TelegraphManager TeleManager => teleManager;

    public ObjectPooler objectPooler;

    public Transform player;

    public Health enemyHealth { get; private set; }

    private AngerState currentState;
    public AngerState standardState = new StandardAngerState();
    public AngerState angryState = new AngryAngerState();

    private void Awake() => enemyHealth = GetComponent<Health>();

    public void Initialise(ObjectPooler pool, Transform playerPos)
    {
        objectPooler = pool;
        player = playerPos;
        currentState = standardState;
        currentState.EnterState(this, enemyHealth);
    }

    void Update() => currentState.UpdateState(this);

    public void SwitchState(AngerState newState)
    {
        currentState = newState;
        newState.EnterState(this, enemyHealth);
    }
}
