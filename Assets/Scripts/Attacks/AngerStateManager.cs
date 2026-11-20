using UnityEngine;

public class AngerStateManager : MonoBehaviour
{
    public ObjectPooler objectPooler;
    private AngerState currentState;
    private AngerState standardState = new StandardAngerState();

    public void Initialise(ObjectPooler pool)
    {
        objectPooler = pool;
        currentState = standardState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
}
