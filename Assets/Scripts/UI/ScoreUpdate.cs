using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private float scoreMultiplier = 1.5f;

    bool gameEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            AddScore();
        }
        else
        {
            SetFinalScore();
        }
    }

    void OnEnable()
    {
        GameManager.OnGameLose += SetGameEnd;
    }

    void OnDisable()
    {
        GameManager.OnGameLose -= SetGameEnd;        
    }

    void SetGameEnd()
    {
        gameEnd = true;
    }

    void AddScore()
    {
        score += 1 + (int)(scoreMultiplier * Time.deltaTime);
        
        if(score % 100 == 0)
        {
            scoreText.text = "Score : " + score;
        }
    }

    void SetFinalScore()
    {
        scoreText.text = "";

        finalScoreText.text = "Final Score: " + score;
    }
}
