using TMPro;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    private TMP_Text enemyText;

    private void Awake() => enemyText = GetComponent<TMP_Text>();
    private void OnEnable() => enemyHealth.HealthChange += UpdateHealth;
    private void OnDisable() => enemyHealth.HealthChange -= UpdateHealth;
    private void Start() => UpdateHealth(enemyHealth.currentHealth, enemyHealth.MaxHealth);
    private void UpdateHealth(float current, float max) => enemyText.text = $"{current:0} / {max:0}";
}