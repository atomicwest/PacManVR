using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to Pellet Group

public class background_sound_controller : MonoBehaviour {

	public AudioClip alarmloop;
	public AudioClip getghost;
	private AudioSource source;
	private GameObject pellets;
	private float savepitch;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		//source.Play ();
		pellets = GameObject.Find ("Pellet_Group");
		StartCoroutine (SwitchAudio ());
	}


	IEnumerator SwitchAudio(){



		while (Time.timeScale != 0) {

			//have 4 grades of pitch depending on number of pellets left in the game
			if (pellets.transform.childCount < 60) {
				source.pitch = 1.3f;

			}
			else if (pellets.transform.childCount < 120)
			{
				source.pitch = 1.2f;
			}
			else if (pellets.transform.childCount < 180)
			{
				source.pitch = 1.1f;
			}



			//play regular alarm thing
			source.Play ();
			yield return new WaitUntil (() => Ghost_Controller.weak);
			savepitch = source.pitch;
			//play ghost vulnerable alarm
			source.pitch = 1;
			source.clip = getghost;
			source.Play ();
			yield return new WaitUntil (() => !Ghost_Controller.weak);
			source.pitch = savepitch;
			source.clip = alarmloop;
			source.Play ();
		}
	}


	// Update is called once per frame
	void Update () {
		/*
		if (pellets.transform.childCount < 100) {
			GameObject.Find("MiniMap").SetActive(true);
		}
		*/

		if (Score_Manager.endgame || gameObject.transform.childCount==0) 
		{
			source.Stop ();
		}

	}
}
