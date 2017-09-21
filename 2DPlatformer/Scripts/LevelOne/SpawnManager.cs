using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns platforms
public class SpawnManager : MonoBehaviour
{
    public int maxPlatform = 20;
    public GameObject platform;
    public GameObject nextLevelPlatform;
    public float horizontalMin = 6.5f;
    public float horizontalMax = 14;
    public float verticalMin = -6;
    public float verticalMax = 6;

    protected Vector2 spawnPosition;

	void Start ()
    {
        spawnPosition = transform.position;
        Spawn();
	}
	
    // Moves spawnPosition randomly and instantiate platform at that position
    private void Spawn()
    {
        SpawnPlatform(platform);
        for(int i = 0; i < maxPlatform; i++)
        {
            RandomizeSpawnPosition();
            SpawnPlatform(platform);
        }
        RandomizeSpawnPosition();
        SpawnPlatform(platform);
    }
    
    // Moves the spawn position under given boundaries
    protected void RandomizeSpawnPosition()
    {
        spawnPosition += new Vector2(Random.Range(horizontalMin, horizontalMax),
            Random.Range(verticalMin, verticalMax));
    }

    protected void SpawnPlatform(GameObject platform)
    {
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }
}
