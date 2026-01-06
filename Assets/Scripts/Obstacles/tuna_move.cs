using UnityEngine;

public class tuna_move : MonoBehaviour
{
    [SerializeField]private float speed;
    
    private SpriteRenderer spriteRenderer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        float screenTop = Camera.main.orthographicSize;

        if (transform.position.y > screenTop + spriteRenderer.bounds.extents.y)
        {
            Destroy(gameObject);
        }
    }
}
