using UnityEngine;

public class AngerStateManager : MonoBehaviour
{
    AngerState currentState;
    AngerState standardState = new StandardAngerState();

    void Start()
    {
        currentState = standardState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }
}
