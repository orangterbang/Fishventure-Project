using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]private float maxSpeed = 2f;
    public float speed = 1.5f;
    private Vector3 playerPosition;

    [Header("Speed Power Up")]
    public float playerSpeedBuff;
    public float playerSpeedBoostTimer;

    [Header("Ultimate Power Up")]
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
        float inputValueX = Input.GetAxisRaw("Horizontal");
        float inputValueY = Input.GetAxisRaw("Vertical");

        bool outOfBoundMovementLeft = inputValueX < 0 && playerPosition.x < -GameBoundary.Instance.screenWidthUnitHalved;
        bool outOfBoundMovementRight = inputValueX > 0 && playerPosition.x > GameBoundary.Instance.screenWidthUnitHalved;

        bool outOfBoundMovementUp = inputValueY < 0 && playerPosition.y < -GameBoundary.Instance.screenHeightUnitHalved;
        bool outOfBoundMovementDown = inputValueY > 0 && playerPosition.y > GameBoundary.Instance.screenHeightUnitHalved;
        
        if(outOfBoundMovementLeft || outOfBoundMovementRight)
        {
            inputValueX = 0f;
        }

        if(outOfBoundMovementUp || outOfBoundMovementDown)
        {
            inputValueY = 0f;
        }

        Vector3 moveDirection = new Vector3(inputValueX, inputValueY).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle") && !CheckShieldUp() && !isPlayerinUltimateForm)
        {
            Destroy(gameObject);
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
        return ShieldManager.Instance.isShieldUp;
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