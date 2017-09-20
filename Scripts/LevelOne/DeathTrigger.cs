using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Restarts level when player touches
// but destroys anything in contact.
public class DeathTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

}
