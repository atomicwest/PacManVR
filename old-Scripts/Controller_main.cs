using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_main : MonoBehaviour {

    //floor==ground

    public GameObject floor;

    private bool walking = false;
    private Vector3 spawnPoint;
    private float speed = 6.5f;

    private int score = 0;

	// Use this for initialization
	void Start () {
        spawnPoint = transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Pellet")) {
            ScoreManager.score += 10;
            Destroy(other.gameObject);
        }
        else if (other.name.Contains("Special"))
        {
            ScoreManager.score += 500;
            Destroy(other.gameObject);
        }

        else if (other.name.Contains("Super"))
        {
            //the ghosts become vulnerable
            ghost_controller.weak = true;
            ScoreManager.score += 50;
            ghost_controller.supertime = 50f;
            Destroy(other.gameObject);
        }

        else if (other.name.Contains("ghost") && ghost_controller.weak)
        {
            //then kill the ghost and make it respawn
            ScoreManager.score += 200;
            ghost_controller.revive = true;
            //ghost_controller.Respawn();
        }

        else if (other.name.Contains("ghost") && ScoreManager.lives == 0)
        {
            ScoreManager.endgame = true;
            Time.timeScale = 0;
        }

        else if (other.name.Contains("ghost"))
        {
            ScoreManager.lives -= 1;
            transform.position = spawnPoint;
        }
        
        else if (other.name.Contains("Portal"))
        {
            if (other.name.Contains("Left")){
                transform.position = GameObject.Find("Portal_Right").transform.position;
            }
            else
            {
                transform.position = GameObject.Find("Portal_Left").transform.position;
            }
        }

    }

    // Update is called once per frame
    void Update () {
		if (walking == true)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

 
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("plane"))
            {
                walking = false;
            }
        /*    else if (hit.collider.name.Contains("Pellet"))
            {
                ScoreManager.score += 1;
            }   */
            else
            {
                walking = true;
            }
        }
        
    }


}
