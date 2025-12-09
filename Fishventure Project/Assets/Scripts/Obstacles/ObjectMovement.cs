using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private SpriteRenderer spriteRenderer;
    private GameBoundary boundary;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boundary = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameBoundary>();
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        speed = gameManager.gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if(transform.position.y > boundary.screenHeightUnitHalved + spriteRenderer.bounds.size.y)
        {
            Destroy(gameObject);
        }
    }
}
