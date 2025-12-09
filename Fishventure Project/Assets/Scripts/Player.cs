using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;
    private GameBoundary boundary;
    private Vector3 playerPosition;

    void Start()
    {
        boundary = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameBoundary>();
    }

    void Update()
    {
        playerPosition = transform.position;
        
        characterMovement();                 
    }

    private void characterMovement()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");

        bool outOfBoundMovementLeft = inputValue < 0 && playerPosition.x < -boundary.screenWidthUnitHalved;
        bool outOfBoundMovementRight = inputValue > 0 && playerPosition.x > boundary.screenWidthUnitHalved;
        
        if(outOfBoundMovementLeft || outOfBoundMovementRight)
        {
            inputValue = 0f;
        }

        Vector3 moveDirection = new Vector3(inputValue, 0f).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Debug.Log("Player hit obstacle");
        }
    }
}