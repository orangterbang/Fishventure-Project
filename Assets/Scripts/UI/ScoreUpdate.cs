using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private float scoreMultiplier = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += 1 + (int)(scoreMultiplier * Time.deltaTime);
        
        if(score % 100 == 0)
        {
            scoreText.text = "Score : " + score;
        }
    }
}
