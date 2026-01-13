using UnityEngine;

public class SwordfishMovement : EnemyManager
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
