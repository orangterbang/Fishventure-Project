using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public static ShieldManager Instance{get; private set;}

    private Animator animator;

    private bool playerHitObstacle;
    public bool isShieldUp = false;

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
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = true;
        shieldTimer = maxShieldTime;
        playerHitObstacle = false;
        isShieldUp = true;
    }

    void DeactivateShield()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        playerHitObstacle = false;
        isShieldUp = false;
    }

    void OnEnable()
    {
        ShieldPowerUp.OnShieldPickUp += ActivateShield;
    }

    void OnDisable()
    {
        ShieldPowerUp.OnShieldPickUp -= ActivateShield;
    }
}
