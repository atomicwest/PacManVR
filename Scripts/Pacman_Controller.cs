using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman_Controller : MonoBehaviour {

    private int score;
	public AudioClip waka;
	public AudioClip eatghost;
	public AudioClip pacdie;


	private AudioSource source;
	private float volNorm = 1.0f;
	private GameObject pellets;
	//private Animation anim;

	// Use this for initialization
	void Start () {
        score = 0;
		source = GetComponent<AudioSource> ();
		//anim["pacman_rig_1"].speed = 3;
		pellets = GameObject.Find("Pellet_Group");
	}

    void OnTriggerEnter(Collider other)
    {
        /*		//delegate this to background_sound
		if (other.name.Contains ("Pellet") | other.name.Contains ("Super")) {
			if (pellets.transform.childCount < 1) {
				Debug.Log ("pacman has  won");
				Time.timeScale = 0;
				Continue_Controller.wingame = true;
				//background_sound_controller.stopsound = true;
			}
		}
		*/
		if (other.name.Contains("Pellet"))
        {
            Score_Manager.score += 10;
            Destroy(other.gameObject);
			source.PlayOneShot (waka,volNorm);
        }

        else if (other.name.Contains("Special"))
        {
            Score_Manager.score += 500;
            Destroy(other.gameObject);
			source.PlayOneShot (waka,volNorm);
        }
			
        else if (other.name.Contains("Super"))
        {
            //Debug.Log("Ghosts should be weak now");
            Ghost_Controller.weak = true;
            Score_Manager.score += 50;
            Ghost_Controller.supertime = 50f;
            Destroy(other.gameObject);
			source.PlayOneShot (waka,volNorm);
        }

        else if (other.name.Contains("ghost") && Ghost_Controller.weak)
        {
            //then kill the ghost and make it respawn
            Score_Manager.score += 200;
			source.PlayOneShot (eatghost,volNorm);
        }
        

        else if (other.name.Contains("ghost") && Score_Manager.lives == 0)
        {
			Debug.Log ("Pacman lost");
			Continue_Controller.losegame = true;
			background_sound_controller.stopsound = true;
            //Time.timeScale = 0;
			source.PlayOneShot (pacdie,volNorm);
        }

        else if (other.name.Contains("ghost"))
        {
			Score_Manager.lives -= 1;
            Controller_Main.dead = true;
			source.PlayOneShot (pacdie,volNorm);
			Time.timeScale = 0;
        }
			
    }

    // Update is called once per frame
    void Update () {
		
	}
}
