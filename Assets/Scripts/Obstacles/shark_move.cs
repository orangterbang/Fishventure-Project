using UnityEngine;

public class shark_move : MonoBehaviour
{
    [SerializeField] private float speed;

    private SpriteRenderer spriteRenderer;
    private float screenLeft;
    private float screenRight;
    private int direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        screenLeft = -halfWidth;
        screenRight = halfWidth;

        // Random side: true = left, false = right
        bool spawnFromLeft = Random.value > 0.5f;

        if (spawnFromLeft)
        {
            // Spawn from LEFT → move RIGHT
            transform.position = new Vector3(
                screenLeft - spriteRenderer.bounds.extents.x,
                transform.position.y,
                0f
            );
            direction = 1;
            spriteRenderer.flipX = false;
        }
        else
        {
            // Spawn from RIGHT → move LEFT
            transform.position = new Vector3(
                screenRight + spriteRenderer.bounds.extents.x,
                transform.position.y,
                0f
            );
            direction = -1;
            spriteRenderer.flipX = true;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        if (direction == 1 &&
            transform.position.x > screenRight + spriteRenderer.bounds.extents.x)
        {
            Destroy(gameObject);
        }
        else if (direction == -1 &&
                 transform.position.x < screenLeft - spriteRenderer.bounds.extents.x)
        {
            Destroy(gameObject);
        }
    }
}
