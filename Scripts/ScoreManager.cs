using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{

    public static int score;
    public static int lives;
    public static bool endgame = false;     //set by Pacman_Controller.cs

	public AudioClip pacwin;
	private AudioSource source;

    private GameObject pellets;

    Text text;

    // Use this for initialization
    void Start()
    {
		source = GetComponent<AudioSource> ();
		text = GetComponent<Text>();
        score = 0;
        lives = 3;
        pellets = GameObject.Find("Pellet_Group");
		//StartCoroutine (Playwin ());

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

	/*
	IEnumerator Playwin() 
	{
		Debug.Log ("inside IEnumerator");


		while (!CheckPellets ()) {
			Debug.Log ("not playing victory yet");
		}

		if (CheckPellets ()) {
			Debug.Log ("should play win");
			source.PlayOneShot (pacwin, 1.0f);
			yield return new WaitForSeconds (5);
		}

	}
	*/

    // Update is called once per frame
    void Update()
    {
        


		text.text = "Score: " + score + "\nLives: " + lives;

        if (endgame)
        {
			text.text = "Game Over | Score: " + score;
			Continue_Controller.waitRestart = true;
        }
        else if (CheckPellets())
        {
			
			Time.timeScale = 0;
            text.text = "You won! Final Score: " + score;
            Continue_Controller.waitRestart = true;
        }
			
    }
}
