using UnityEngine;
using TMPro;

public class Suspicion : MonoBehaviour
{
    public int Severity;
    public TextMeshProUGUI SeverityText;
    Color Green;
    Color Red;
    public bool isDetected;

    void Start()
    {
        Severity = 0;
        SeverityText.text = "Undetected";
        Green = new Color(0, 255, 0);
        Red = new Color(255, 0, 0);
        SeverityText.color = Green;
        SeverityText.enabled = false;
    }

    public void IncreaseSeverity (int amount)
    {
        Severity += amount;
        if (Severity >= 3)
        {
            isDetected = true;
            SeverityText.text = "Detected";
            SeverityText.color = Red;
        }
    }

    public void ResetSeverity()
    {
        Severity = 0;
        isDetected = false;
        SeverityText.text = "Undetected";
        SeverityText.color = Green;
    }

    public void DecreaseSeverity(int amount)
    {
        Severity -= amount;
        if (Severity <= 2)
        {
            isDetected = false;
            SeverityText.text = "Undetected";
            SeverityText.color = Green;
        }
    }
}