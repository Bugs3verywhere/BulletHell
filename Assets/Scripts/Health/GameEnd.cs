using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Health enemyHealth;

    void Awake()
    {
        playerHealth.Died += GameLose;
        enemyHealth.Died += GameWin;
    }

    private void GameLose() => Time.timeScale = 0;
    private void GameWin() => Time.timeScale = 0;
}
