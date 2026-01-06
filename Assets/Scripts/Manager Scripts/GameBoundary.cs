using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    public static GameBoundary Instance;
    [SerializeField]public float screenHeightUnit{get; private set;}
    [SerializeField]public float screenHeightUnitHalved{get; private set;}
    [SerializeField]public float screenWidthUnit{get; private set;}
    [SerializeField]public float screenWidthUnitHalved{get; private set;}
    
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

    void Start()
    {
        //Check the screen width in game position
        screenHeightUnit = Camera.main.orthographicSize * 2;
        screenHeightUnitHalved = Camera.main.orthographicSize;
        screenWidthUnit = screenHeightUnit * Camera.main.aspect;
        screenWidthUnitHalved = screenWidthUnit / 2f;
    }
}
