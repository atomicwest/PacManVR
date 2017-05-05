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

	//private Animation anim;

	// Use this for initialization
	void Start () {
        score = 0;
		source = GetComponent<AudioSource> ();
		//anim["pacman_rig_1"].speed = 3;
	}

    void OnTriggerEnter(Collider other)
    {
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
			Score_Manager.endgame = true;
            Time.timeScale = 0;
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
