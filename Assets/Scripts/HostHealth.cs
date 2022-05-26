using UnityEngine;

public class HostHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public void StartHost(float health)
    {
        currentHealth = health;
        FindObjectOfType<HealthBar>().Host = this;
        FindObjectOfType<HealthBar>().UpdateHostHealth();
    }

    public void TakeDamage(float damage)
    {
        FindObjectOfType<Lifetime>().TakeDamage(damage);
    }
}