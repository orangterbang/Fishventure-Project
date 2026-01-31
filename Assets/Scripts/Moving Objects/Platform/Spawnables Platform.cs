using UnityEngine;

//class that will hold each platform prefab in platform manager array
//Will add variables like spawn rate of power ups
//Add options for each platform if enemies can spawn here
[CreateAssetMenu(menuName = "Spawnables/Platform")]
public class SpawnablesPlatform : ScriptableObject
{
    public GameObject platform;
    public SpawnRule[] spawnRules;
}

[System.Serializable]
public class SpawnRule
{
    public SpawnPointType pointType;
    public GameObject spawnPrefab;
    [Range(0f, 1f)] public float spawnChance;
}
