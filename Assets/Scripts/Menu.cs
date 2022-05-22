using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject About;
    private bool isAboutOpen = false;

    private bool isMuted = true;
    public TextMeshProUGUI MuteText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Muted"))
        {
            if (PlayerPrefs.GetInt("Muted") == 1)
            {
                isMuted = true;
                MuteText.text = "Unmute";
                AudioListener.volume = 0;
            }
            else
            {
                isMuted = false;
                MuteText.text = "Mute";
                AudioListener.volume = 1;
            }
        }
    }

    public void AboutClick()
    {
        if (isAboutOpen)
        {
            About.SetActive(false);
            isAboutOpen = false;
        }
        else
        {
            About.SetActive(true);
            isAboutOpen = true;
        }
    }

    public void MuteClick()
    {
        if (isMuted)
        {
            isMuted = false;
            MuteText.text = "Mute";
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Muted", 0);
        }
        else
        {
            isMuted = true;
            MuteText.text = "Unmute";
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Muted", 1);
        }
    }

    public void StartGame()
    {
        FindObjectOfType<SceneLoader>().LoadScene(1);
    }
}
