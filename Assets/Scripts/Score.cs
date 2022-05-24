using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    private float TimeBetweenScores = 2f;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (TimeBetweenScores <= 0)
        {
            AddScore(Random.Range(1, 3));
            TimeBetweenScores = 2f;
        }
        else
        {
            TimeBetweenScores -= Time.deltaTime;
        }
    }
}
