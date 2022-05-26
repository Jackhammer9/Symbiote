using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            FindObjectOfType<Score>().AddScore(Random.Range(10, 20));
            currentHealth = maxHealth;
            FindObjectOfType<SoldierSpawner>().Revive(gameObject);
        }
    }
}