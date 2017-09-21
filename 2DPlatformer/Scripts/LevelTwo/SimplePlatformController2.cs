using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Switchable color on the player
// Left click to be red
// Right click to be blue
public class SimplePlatformController2 : SimplePlatformController 
{
    private bool isRed;
    private bool isBlue;
    public GameObject colorCoating;
    private Renderer auraColor;

    private void Start()
    {
        base.Start();
        isBlue = true;
        isRed = false;
    }

    private void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if(isRed)
            {
                SwitchColor();
                UpdateColor();
            }
        }
        if(Input.GetButtonDown("Fire2"))
        {
            if(isBlue)
            {
                SwitchColor();
                UpdateColor();
            }
        }
    }

    public void SwitchColor()
    {
        isRed = !isRed;
        isBlue = !isBlue;
    }

    // TODO:
    // Add sprites instead of objects
    private void UpdateColor()
    {
        if(isRed && !isBlue)
        {
            // auraColor.material.color = Color.blue;
            // auraColor.material.SetColor("_Color", Color.blue);
        }
        else if(!isRed && isBlue)
        {
            // auraColor.material.color = Color.red;
            // auraColor.material.SetColor("_Color", Color.red);
        }
    }

    // Returns what color mode the player is on
    public string GetColor()
    {
        if(isRed)
        {
            return "Red";
        }
        else if(isBlue)
        {
            return "Blue";
        }
        else
        {
            Debug.Log("Error, both colors are false");
            return null;
        }
    }
}
