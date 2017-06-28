using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//attach this to any object in the first scene

public class Intro_Controller : MonoBehaviour {

	public AudioClip introtheme;
	private AudioSource source; 

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (introtheme, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.realtimeSinceStartup >= 10) 
		{
			SceneManager.LoadScene (1);
		}*/
		if (Time.timeSinceLevelLoad >= 8) {
			SceneManager.LoadScene (3);
		}
	}
}
