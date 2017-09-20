using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int score;
    public Text scoreDisplay;

	private void Start ()
    {
        scoreDisplay = scoreDisplay.GetComponent<Text>();
        score = 0;
        scoreDisplay.text = "Score: ";
	}

    public void AddScore(int num)
    {
        score += num;
    }
    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
