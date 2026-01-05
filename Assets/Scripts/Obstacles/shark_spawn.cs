using UnityEngine;
using System.Collections;

public class shark_spawn : MonoBehaviour
{
    [SerializeField] private GameObject sharkPrefab;
    [SerializeField] private float minSpawnDelay = 4f;
    [SerializeField] private float maxSpawnDelay = 8f;
    [SerializeField] private float minSpawnDistance = 1.5f;
    [SerializeField] private LayerMask sharkLayer;

    float left;
    float right;
    float top;
    float bottom;

    void Start()
    {
        Camera cam = Camera.main;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        left = -halfWidth;
        right = halfWidth;
        top = halfHeight;
        bottom = -halfHeight;

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            SpawnShark();
        }
    }

    void SpawnShark()
    {
        float y = Random.Range(bottom + 1f, top - 1f);

        bool spawnFromLeft = Random.value > 0.5f;
        float x = spawnFromLeft ? left - 1f : right + 1f;

        Vector3 pos = new Vector3(x, y, 0f);

        // Prevent overlap
        if (Physics2D.OverlapCircle(pos, minSpawnDistance, sharkLayer))
            return;

        Instantiate(sharkPrefab, pos, Quaternion.identity);
    }
}
