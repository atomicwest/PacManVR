using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman_Controller : MonoBehaviour {

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Pellet"))
        {
            Score_Manager.score += 10;
            Destroy(other.gameObject);
        }
        else if (other.name.Contains("Special"))
        {
            Score_Manager.score += 500;
            Destroy(other.gameObject);
        }

        
        else if (other.name.Contains("Super"))
        {
            //the ghosts become vulnerable
            Ghost_Controller.weak = true;
            Score_Manager.score += 50;
            Ghost_Controller.supertime = 50f;
            Destroy(other.gameObject);
        }

        else if (other.name.Contains("ghost") && Ghost_Controller.weak)
        {
            //then kill the ghost and make it respawn
            Score_Manager.score += 200;
            Ghost_Controller.revive = true;
            //Ghost_Controller.Respawn();
        }
        

        else if (other.name.Contains("ghost") && Score_Manager.lives == 0)
        {
            Score_Manager.endgame = true;
            Time.timeScale = 0;
        }

        else if (other.name.Contains("ghost"))
        {
            Score_Manager.lives -= 1;
            Controller_Main.dead = true;
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
