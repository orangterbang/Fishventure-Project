using System.Numerics;
using UnityEngine;

public class fish_direct : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (UnityEngine.Vector3.up * moveSpeed) * Time.deltaTime;
    }
}
