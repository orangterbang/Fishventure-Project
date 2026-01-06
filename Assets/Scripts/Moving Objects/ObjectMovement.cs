using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        speed = GameManager.Instance.maxGameSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        speed = GameManager.Instance.gameSpeed;

        transform.position += Vector3.up * speed * Time.deltaTime;

        if(transform.position.y > GameBoundary.Instance.screenHeightUnitHalved + spriteRenderer.bounds.size.y)
        {
            Destroy(gameObject);
        }
    }
}
