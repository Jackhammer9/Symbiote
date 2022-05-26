using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBarImage;
    PlayerHealth Player;
    [HideInInspector] public HostHealth Host;

    void Start()
    {
        Player = FindObjectOfType<PlayerHealth>();
    }

    public void UpdateHealth()
    {
        HealthBarImage.fillAmount = Player.currentHealth / (float)Player.maxHealth;
    }

        public void UpdateHostHealth()
    {
        HealthBarImage.fillAmount = Host.currentHealth / (float)Host.maxHealth;
    }

}