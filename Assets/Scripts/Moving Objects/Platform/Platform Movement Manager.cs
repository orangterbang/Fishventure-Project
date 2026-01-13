using UnityEngine;

public class PlatformMovementManager : MonoBehaviour
{
    [SerializeField]private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = GameManager.Instance.maxGameSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        speed = GameManager.Instance.gameSpeed;

        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("End Platform"))
        {
            Destroy(gameObject);
        }
    }
}
