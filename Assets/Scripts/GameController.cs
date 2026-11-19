using UnityEngine;

public class GameController : MonoBehaviour
{
    private AttackManager attackManager;

    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject homing;
    [SerializeField] private GameObject healing;
    private GameObject player;
    private GameObject enemy;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        attackManager = new AttackManager(player.transform, enemy, standard, homing, healing);
    }
}
