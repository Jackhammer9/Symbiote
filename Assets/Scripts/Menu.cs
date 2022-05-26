using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject About;
    private bool isAboutOpen = false;

    private bool isMuted = true;
    public TextMeshProUGUI MuteText;
    public TextMeshProUGUI htp;
    public GameObject GuidePanel;
    private int count;
    public GameObject ControlPanel;
    public TextMeshProUGUI HighScore;

    void Start()
    {
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
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

    public void OpenHTPPanel()
    {
        GuidePanel.SetActive(true);
    }

    public void Next()
    {
        count ++;

        if (count == 1)
        {
            htp.text= "the time passes your health will reduce the longer you don't feed on host. Your symbiote's health will be replineshed when you feed on your host";
        }
        else if(count == 2)
        {
            htp.text = "You can feed on your host by pressing the 'F' key when you are in range of the host , but be aware of the surroundings if you do it near other soldiers they will attack you";
        }
        else if (count == 3)
        {
            htp.text = "Going infront of the soldiers as a symbiote will make them attack you hence it is best to take over them from back";
        }
        else if (count == 4)
        {
            htp.text = "The longer you take a soldier as host, the more health your symbiote would gain";
        }
        else if (count == 5)
        {
            htp.text = "You must revert back to your symbiote after feeding on a host before he dies if you fail to do so your symbiote would die with the host";
        }
        else if (count == 6)
        {
            htp.text = "You can revert back to your symbiote form anytime by pressing the 'R' key";
        }
        else if (count == 7)
        {
            htp.text = "After taking on a host, you can kill other soldiers which would earn you additional score but doing so is risky as it can lead to other soldiers targeting you";
        }
        else if (count == 8)
        {
            htp.text = "To get away from a group of soldiers or travel faster you can teleport around the map";
        }
        else if (count == 9)
        {
            htp.text = "You can press 'E' key to know where the nearest portals is, and aim at it, clicking on it will teleport you to the location";
        }
        else if (count == 10)
        {
            count = 0;
            GuidePanel.SetActive(false);
            htp.text = "you play as a symbiote on an alien planet with soldiers walking around your goal is to survive. As a symbiote you must take over soldiers and feed on them before you die";
        }
    }

    public void OpenControlPanel()
    {
        ControlPanel.SetActive(true);
    }

    public void CloseControlPanel()
    {
        ControlPanel.SetActive(false);
    }
}
