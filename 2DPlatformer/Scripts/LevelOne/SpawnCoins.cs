using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns coins randomly from given transforms
public class SpawnCoins : MonoBehaviour
{
    public Transform[] coinSpawns;
    public GameObject coin;

    private void Start()
    {
        Spawn();
    }

    // Randomly spawn coins in the given areas
    private void Spawn()
    {
        int coinFlip;
        for(int i = 0; i < coinSpawns.Length; i++)
        {
            coinFlip = Random.Range(0, 2);
            if(coinFlip > 0)
            {
                Instantiate(coin, coinSpawns[i].position,Quaternion.identity);
            }
        }
    }
	
}
