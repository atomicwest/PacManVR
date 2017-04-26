using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int lives;
    public static bool endgame = false;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        score = 0;
        lives = 3;
	}

	// Update is called once per frame
	void Update () {
        text.text = "Score: " + score + "\nLives: " + lives;

        if (endgame)
        {
            text.text = "Game Over | Score: " + score;
        }

	}
}
