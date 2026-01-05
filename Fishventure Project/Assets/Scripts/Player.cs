using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]private float maxSpeed = 2f;
    public float speed = 1.5f;
    private Vector3 playerPosition;

    [Header("Power Up")]
    public float playerSpeedBuff;
    public float playerSpeedBoostTimer;
    public GameObject shieldObject;
    public Vector3 playerUltimateSizeIncrease;
    [SerializeField]private Vector3 playerOriginSize;
    public float ultimateTimer;
    public float ultimateTimerMaxTime;
    public float ultimateTimeReduceRate;
    public bool isPlayerinUltimateForm;

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
        speed = maxSpeed;

        playerOriginSize = gameObject.transform.localScale;
    }
    void Update()
    {
        playerPosition = transform.position;
        
        characterMovement();      
        UpdatePlayerSpeed();
        UpdateUltimateDuration();      
    }

    private void characterMovement()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");

        bool outOfBoundMovementLeft = inputValue < 0 && playerPosition.x < -GameBoundary.Instance.screenWidthUnitHalved;
        bool outOfBoundMovementRight = inputValue > 0 && playerPosition.x > GameBoundary.Instance.screenWidthUnitHalved;
        
        if(outOfBoundMovementLeft || outOfBoundMovementRight)
        {
            inputValue = 0f;
        }

        Vector3 moveDirection = new Vector3(inputValue, 0f).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle") && !CheckShieldUp() && !isPlayerinUltimateForm)
        {
            Destroy(gameObject);
            Debug.Log("Player hit obstacle");
        }
    }

    void OnEnable()
    {
        SpeedPowerUp.OnSpeedPickUp += BoostPlayerSpeed;
        UltimatePowerUp.OnUltimatePickUp += UltimateBuff;
    }

    void OnDisable()
    {
        SpeedPowerUp.OnSpeedPickUp -= BoostPlayerSpeed;
        UltimatePowerUp.OnUltimatePickUp -= UltimateBuff;
    }

    void BoostPlayerSpeed()
    {
        speed = playerSpeedBuff;
    }

    //Speed PowerUp
    void UpdatePlayerSpeed()
    {
        if(speed > maxSpeed)
        {
            speed -= (float)(playerSpeedBoostTimer * Time.deltaTime);
        }else if(speed < maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    //Shield PowerUp
    bool CheckShieldUp()
    {
        return shieldObject.activeSelf;
    }

    //Ultimate PowerUp
    void UltimateBuff()
    {
        transform.localScale = playerUltimateSizeIncrease;
        ultimateTimer = ultimateTimerMaxTime;
        isPlayerinUltimateForm = true;
    }

    void RevertToOriginalScale()
    {
        transform.localScale = playerOriginSize;
        isPlayerinUltimateForm = false;
    }

    void UpdateUltimateDuration()
    {
        if(ultimateTimer > 0)
        {
            ultimateTimer -= ultimateTimeReduceRate * Time.deltaTime;
        }else
        {
            RevertToOriginalScale();
        }
    }
}