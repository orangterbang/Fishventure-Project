using UnityEngine;

public class TunaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tunaPrefab;
    [SerializeField] private float spawnInterval = 1.5f;

    private float screenBottom;
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        Camera cam = Camera.main;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        screenBottom = -halfHeight;
        screenLeft = -halfWidth;
        screenRight = halfWidth;

        InvokeRepeating(nameof(SpawnTuna), 0f, spawnInterval);
    }

    void SpawnTuna()
    {
        float randomX = Random.Range(screenLeft, screenRight);
        Vector3 spawnPos = new Vector3(
            randomX,
            screenBottom - 0.5f, // slightly off-screen
            0f
        );

        Instantiate(tunaPrefab, spawnPos, Quaternion.identity);
    }
}

