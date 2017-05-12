using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//attach to the UI element that tracks score

public class Score_Manager : MonoBehaviour
{

    public static int score = 0;
    public static int lives = 3;

    Text text;

	//awake is only called once
	void Awake(){
		text = GetComponent<Text>();
		//score = 0;
		//lives = 3;
	}

    // Use this for initialization
    void Start()
    {
		//DontDestroyOnLoad (gameObject);
    }
		

    // Update is called once per frame
    void Update()
    {
		text.text = "Score: " + score + "\nLives: " + lives;
    }
}
