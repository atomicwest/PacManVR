using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{

    public static int score;
    public static int lives;
    public static bool endgame = false;

    private GameObject pellets;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
        lives = 3;
        pellets = GameObject.Find("Pellet_Group");
    }

    bool CheckPellets()
    {
        if (pellets.transform.childCount <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score + "\nLives: " + lives;

        if (endgame)
        {
            text.text = "Game Over | Score: " + score;
        }
        else if (CheckPellets())
        {
            Time.timeScale = 0;
            text.text = "You won! Final Score: " + score;
        }

    }
}
