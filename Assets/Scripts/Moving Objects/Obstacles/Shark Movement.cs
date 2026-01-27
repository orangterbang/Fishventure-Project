using UnityEngine;

public class SharkMovement : EnemyManager
{
    private SpriteRenderer spriteRenderer;
    private float screenRight;
    private int direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        screenRight = GameBoundary.Instance.screenWidthUnitHalved;

        // Random side: true = left, false = right
        bool isSpawnFromRight = transform.position.x > screenRight;

        if (!isSpawnFromRight)
        {
            direction = 1;
            
            spriteRenderer.flipX = false;
        }
        else
        {
            direction = -1;
            warningPath.transform.localPosition *= -1f;
            spriteRenderer.flipX = true;
        }
    
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }
}
