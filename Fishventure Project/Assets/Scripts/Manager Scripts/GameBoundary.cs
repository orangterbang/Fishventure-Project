using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    [SerializeField]public float screenHeightUnit{get; private set;}
    [SerializeField]public float screenHeightUnitHalved{get; private set;}
    [SerializeField]public float screenWidthUnit{get; private set;}
    [SerializeField]public float screenWidthUnitHalved{get; private set;}
    
    void Awake()
    {
        //Check the screen width in game position
        screenHeightUnit = Camera.main.orthographicSize * 2;
        screenHeightUnitHalved = Camera.main.orthographicSize;
        screenWidthUnit = screenHeightUnit * Camera.main.aspect;
        screenWidthUnitHalved = screenWidthUnit / 2f;
    }
}
