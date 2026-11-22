using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 1000;
    public float currentHealth { get; set; }
    public float MaxHealth => maxHealth;

    public event Action<float, float> HealthChange;
    public event Action Died;

    private void Awake() => currentHealth = maxHealth;

    public void Damage(float power)
    {
        if (currentHealth <= 0) return;
        SetHealth(currentHealth -= power);
        if (currentHealth <= 0) Died?.Invoke();
    }

    protected void SetHealth(float amount)
    {
        currentHealth = Mathf.Clamp(amount, 0f, maxHealth);
        HealthChange?.Invoke(currentHealth, maxHealth);
    }
}
