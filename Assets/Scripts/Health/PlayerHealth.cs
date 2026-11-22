using UnityEngine;

public class PlayerHealth : Health, IHealable
{
    public void Heal(float power)
    {
        if (currentHealth <= 0) return;
        SetHealth(currentHealth + power);
    }
}
