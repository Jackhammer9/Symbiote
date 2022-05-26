using UnityEngine;
using TMPro;

public class Lifetime : MonoBehaviour
{
    [HideInInspector] public bool isPossessing;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI PossesionText;
    private float Timer;
    private float HealthGained;
    private float StartTime;

    void Start()
    {
        isPossessing = false;
        Timer = 120;
    }

    public void ChangeState(bool state , float Time)
    {
        isPossessing = state;
        this.Timer = Time;
        if(isPossessing)
        {
            this.StartTime = Time;
            HealthGained = 0;
            PossesionText.text = "Host Life Time: ";
        }
        else
        {
            if (HealthGained + Timer> FindObjectOfType<HostHealth>().maxHealth)
            {
                Timer = FindObjectOfType<PlayerHealth>().maxHealth;
            }
            else
            {
               Timer += HealthGained;
            }
            PossesionText.text = "Symbiote Life: ";
        }
    }

    void Update()
    {
        TimerText.text = Timer.ToString("F0");
        Timer -= Time.deltaTime;

        if (isPossessing)
        {
            HealthGained = StartTime - Timer;
            FindObjectOfType<HostHealth>().currentHealth = Timer;
            FindObjectOfType<HealthBar>().UpdateHostHealth();
        }
        else
        {
            FindObjectOfType<PlayerHealth>().currentHealth = Timer;
            FindObjectOfType<HealthBar>().UpdateHealth();
        }
    }

    public void TakeDamage(float damage)
    {
      Timer -= damage;
    }
}
