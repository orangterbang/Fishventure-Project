using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate Instance { get; private set;}
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text bestScoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private float scoreMultiplier = 1.5f;
    [SerializeField] private int highestScore;

    private const string HighScoreKey = "HighScore";

    bool gameEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        highestScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            UpdateScore();
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

    void UpdateScore()
    {
        score += 1 + (int)(scoreMultiplier * Time.deltaTime);
        
        if(score % 100 == 0)
        {
            scoreText.text = "Score : " + score;
        }
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    void SetFinalScore()
    {
        CheckforHighScore();

        scoreText.text = "";

        finalScoreText.text = "Final Score: " + score;
        bestScoreText.text = "Best Score: " + highestScore;
    }

    void CheckforHighScore()
    {
        if(score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highestScore);
            PlayerPrefs.Save();
        }
    }
}
