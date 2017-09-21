using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pass-through when player is in blue mode
public class RedGround : PlatformFall
{
    [HideInInspector] public BoxCollider2D bc2d;

    protected void Awake()
    {
        base.Awake();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SimplePlatformController2 player = other.gameObject.GetComponent<SimplePlatformController2>();
            if(player.GetColor().Equals("Red"))
            {
                Invoke("Fall", fallDelay);
            }
            //else if(player.GetColor().Equals("Blue"))
            //{
            //    player.grounded = false;
            //    bc2d.isTrigger = true;
            //}
            //else
            //{
            //    Debug.Log("Else block Reached in Redground class");
            //}
        }
    }

}
