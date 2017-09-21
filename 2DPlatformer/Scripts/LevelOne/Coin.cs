using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy on touch by the player
public class Coin : MonoBehaviour 
{
    private GameController gameController;

    private void Start()
    {
        // Find GameController.
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject == null)
        {
            Debug.Log("GameController not found");
        }
        else
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameController.AddScore(10);
            gameController.UpdateScore();
            Destroy(gameObject);
        }
    }
}
