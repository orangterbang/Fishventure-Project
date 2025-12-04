using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.5f;

    [SerializeField]private float screenHeightUnit;
    [SerializeField]private float screenWidthUnit;
    [SerializeField]private float screenWidthUnitHalved;
    
    private Vector3 playerPosition;

    void Start()
    {
        //Check the screen width in game position
        screenHeightUnit = Camera.main.orthographicSize * 2;
        screenWidthUnit = screenHeightUnit * Camera.main.aspect;
        screenWidthUnitHalved = screenWidthUnit / 2f;
    }

    void Update()
    {
        playerPosition = transform.position;
        
        characterMovement();                 
    }

    private void characterMovement()
    {
        float inputValue = Input.GetAxisRaw("Horizontal");

        bool outOfBoundMovementLeft = inputValue < 0 && playerPosition.x < -screenWidthUnitHalved;
        bool outOfBoundMovementRight = inputValue > 0 && playerPosition.x > screenWidthUnitHalved;
        
        if(outOfBoundMovementLeft || outOfBoundMovementRight)
        {
            inputValue = 0f;
        }

        Vector3 moveDirection = new Vector3(inputValue, 0f).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}