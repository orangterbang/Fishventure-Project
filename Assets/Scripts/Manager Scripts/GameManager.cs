using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}

    [field: SerializeField] 
    public float gameSpeed;
    public float maxGameSpeed;
    public float gameSpeedBuff;
    public GameObject playerObject;

    public static event Action OnGameLose;
    
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

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameSpeed();
        UpdateGameReplay();
    }

    void OnEnable()
    {
        UltimatePowerUp.OnUltimatePickUp += UltimateBuff;
    }

    void OnDisable()
    {
        UltimatePowerUp.OnUltimatePickUp -= UltimateBuff;
    }

    void UltimateBuff()
    {
        gameSpeed = gameSpeedBuff;
    }

    void UpdateGameSpeed()
    {
        if(Player.Instance.ultimateTimer <= 0)
        {
            gameSpeed = maxGameSpeed;
        }
    }

    void UpdateGameReplay()
    {
        if (playerObject != null)
        {
            return;
        }
        
        OnGameLose?.Invoke();
    }
}
