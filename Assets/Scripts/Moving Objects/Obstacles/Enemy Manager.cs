using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float initialSpeed = 0f;
    [SerializeField] private float maxSpeed;
    [SerializeField] protected float speed;
    [SerializeField] protected float offset;
    protected float bottom;

    public GameObject warningPath;
    public Transform movementPoint;

    void Start()
    {
        bottom = -GameBoundary.Instance.screenHeightUnitHalved;
        warningPath.SetActive(true);
        speed = initialSpeed;
    }

    protected virtual void Update()
    {
        if(movementPoint.position.y > bottom + offset)
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        warningPath.SetActive(false);
        speed = maxSpeed;
    }
}
