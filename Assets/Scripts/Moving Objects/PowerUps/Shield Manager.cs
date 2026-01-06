using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public static ShieldManager Instance{get; private set;}

    private Animator animator;

    private bool playerHitObstacle;

    public float shieldTimer;
    public float shieldTimerReduceRate;
    [SerializeField]private float maxShieldTime;

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

        ShieldPowerUp.OnShieldPickUp += ActivateShield;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeactivateShield();
        playerHitObstacle = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Reduce timer only when shield is active
        if (gameObject.activeSelf && playerHitObstacle == false)
        {
            shieldTimer -= shieldTimerReduceRate * Time.deltaTime;
            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Obstacle"))
        {
            return;
        }

        playerHitObstacle = true;
        animator.SetBool("isDestroyed", playerHitObstacle);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Obstacle"))
        {
            return;
        }
        
        DeactivateShield();
    }

    void ActivateShield()
    {
        gameObject.SetActive(true);
        shieldTimer = maxShieldTime;
        playerHitObstacle = false;
    }

    void DeactivateShield()
    {
        gameObject.SetActive(false);
        playerHitObstacle = false;
    }

    void OnDestroy()
    {
        ShieldPowerUp.OnShieldPickUp -= ActivateShield;
    }
}
