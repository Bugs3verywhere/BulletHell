using UnityEngine;

public class GameController : MonoBehaviour
{
    private AttackManager attackManager;

    [SerializeField] private GameObject standard;
    [SerializeField] private GameObject homing;
    [SerializeField] private GameObject healing;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        attackManager = new AttackManager(player.transform, standard, homing, healing);
    }
}
