using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//attach to a second UI text element that only shows up at the end

public class Continue_Controller : MonoBehaviour {

	private static GameObject pellets;
	private int cont_count = 10;

	public AudioClip pacwin;
	private AudioSource source;

	static Text text;

	public static int score;

	public static bool losegame = false;     //set by Pacman_Controller.cs if the player lost and has no lives
	public static bool wingame = false;		//set by Pacman_Controller.cs if the player won, needed to increase ghost speed

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		text = GameObject.Find("Continue_Text").GetComponent<Text> ();
		Debug.Log ("Entered Continue Controller");


		if (wingame)					//delegate this check to PacMan controller
		{
			source.PlayOneShot (pacwin,1.0f);
		}

		StartCoroutine (Cont_Restart());


	}



	//coroutine will be called by the callback
	IEnumerator Cont_Restart() {
		
		int cont_count = 9;
		//text.text = "\nShake head to Exit \n or wait to continue: \n ";
		while(cont_count > 0) {

			if (Mathf.Abs(Input.acceleration.x) > 2 || Mathf.Abs(Input.acceleration.z) > 2) {
				Application.Quit ();
			}
			if (losegame)
			{
				text.text = "Game Over\nShake head to Exit\nor wait to continue:  " + cont_count;
			}
			else if (wingame)					//delegate this check to PacMan controller
			{
				text.text = "You won!\nShake head to Exit\nor wait to continue:  " + cont_count;
			}

			//String withoutLast = yourString.Substring(0,yourString.Length -1);

			//text.text = text.text.Substring(0,text.text.Length-1) + cont_count.ToString();
			yield return new WaitForSecondsRealtime (1);
			cont_count -= 1;
		}

		Time.timeScale = 1;
		background_sound_controller.stopsound = false;
		if (losegame) {
			Score_Manager.score = 0;
			Score_Manager.lives = 3;
		} else if (wingame) {
			Ghost_chase.speed += 0.5f;
		}
		SceneManager.LoadScene (1);
		//SceneManager.LoadSceneAsync (0);
		//yield break;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
