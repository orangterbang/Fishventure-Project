using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}

    [field: SerializeField] 
    public float gameSpeed;
    public float maxGameSpeed;
    public float gameSpeedBuff;
    
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
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameSpeed();
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
}
