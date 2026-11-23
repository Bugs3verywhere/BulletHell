using UnityEngine;

public class AngerStateManager : MonoBehaviour
{
    [SerializeField] private TelegraphManager teleManager;
    public TelegraphManager TeleManager => teleManager;

    public ObjectPooler objectPooler;

    public Transform player;

    private AngerState currentState;
    private AngerState standardState = new StandardAngerState();

    public void Initialise(ObjectPooler pool, Transform playerPos)
    {
        objectPooler = pool;
        player = playerPos;
        currentState = standardState;
        currentState.EnterState(this);
    }

    void Update() => currentState.UpdateState(this);
}
