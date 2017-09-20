using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextLevelDoor : MonoBehaviour 
{
	public GameObject door;

	private void Start()
	{
		Spawn();
	}
    
	private void Spawn()
	{
		Instantiate (door, door.transform.position + gameObject.transform.position, Quaternion.identity);
	}
}
