using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour 
{
    public float fallDelay;
    private Rigidbody2D rb2d;

	protected void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay); // Calls Fall() after fallDelay time is passed
        }
    }
    
    private void Fall()
    {
        rb2d.isKinematic = false;
    }
}
