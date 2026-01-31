using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { get; private set;}
    
    [Header("Platform Spawn Location")]
    [SerializeField] private Vector2 spawnLocation;

    [Header("Platform")]
    public SpawnablesPlatform[] platforms;
    private SpawnablesPlatform preset;
    private int index = 0;

    public static event System.Action OnTriggerEnemyMovement;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Pattern Platform"))
        {
            index = Random.Range(0, platforms.Length);
            preset = platforms[index];
            GameObject platformPrefabs = platforms[index].platform;

            SpawnPlatform(new Vector3(spawnLocation.x, spawnLocation.y, 0), platformPrefabs);
            OnTriggerEnemyMovement?.Invoke();
        }
    }

    private void SpawnPlatform(Vector3 position, GameObject platformPrefab)
    {
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);

        // Find all spawn points in this platform
        SpawnPoint[] points = platform.GetComponentsInChildren<SpawnPoint>();

        foreach (var point in points)
        {
            TrySpawnAtPoint(point);
        }
    }

    // Handles spawning at a single point based on preset rules
    private void TrySpawnAtPoint(SpawnPoint point)
    {
        foreach (var rule in preset.spawnRules)
        {
            if (rule.pointType != point.spawnPointType) continue;

            if (Random.value <= rule.spawnChance)
            {
                Instantiate(
                    rule.spawnPrefab,
                    point.transform.position,
                    Quaternion.identity
                );
            }
        }
    }
}
