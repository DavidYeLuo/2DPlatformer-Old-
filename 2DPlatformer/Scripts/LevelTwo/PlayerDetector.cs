using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Alerts the ground object that the player is about to land
public class PlayerDetector : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject ground;
    private SimplePlatformController2 player;

    private void Awake()
    {
        player = playerObject.GetComponent<SimplePlatformController2>();
    }

    // Todo:
    // Figure out that player.GetColor().Equals(ground.GetColor());

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SimplePlatformController2 player = other.GetComponent<SimplePlatformController2>();
            if (player.GetColor().Equals("Blue") && player)
            {
                player.grounded = false;
                ground.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
}
