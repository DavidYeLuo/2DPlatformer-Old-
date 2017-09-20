using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2: SpawnManager
{
    private GameObject bluePlatform;
    public GameObject redPlatform;
    
	void Start ()
    {
        bluePlatform = platform;
        spawnPosition = transform.position;
        Spawn();
	}
    
    private void Spawn()
    {
        SpawnPlatform(bluePlatform); // First Platform that Player lands.

        for (int i = 0; i < maxPlatform; i++)
        {
            RandomizeSpawnPosition();
            if (Random.Range(0, 2) == 0)
            {
                SpawnPlatform(bluePlatform);
            }
            else
            {
                SpawnPlatform(redPlatform);
            }
        }
        RandomizeSpawnPosition();
        SpawnPlatform(nextLevelPlatform);
    }

    // Spawns a desired platform at SpawnPosition with default rotation.
    private void SpawnPlatform(GameObject platform)
    {
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }
}
