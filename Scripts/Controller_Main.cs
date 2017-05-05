using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Main : MonoBehaviour {

    private bool moving = false;
    private Vector3 spawnPoint;
    private float speed = 7.5f;
    private Vector3 lastpos;

    public static bool dead;

    // Use this for initialization
    void Start () {
        //start the animation
        spawnPoint = GameObject.Find("Pacman_Respawn_Point").transform.position;
        moving = true;
        dead = false;
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Portal_Right"))
        {
            transform.position = GameObject.Find("Portal_Left").transform.position;
        }

        else if (other.name.Contains("Portal_Left"))
        {
            transform.position = GameObject.Find("Portal_Right").transform.position;
        }
    }
		

    IEnumerator Revive()
    {
		transform.position = spawnPoint;

		dead = false;

		yield return new WaitForSecondsRealtime (1);

		Time.timeScale = 1;
		yield break;
    }


	// Update is called once per frame
	void Update () {

        //call when hitting a ghost without super pellet
        if (dead)
        {
            //Debug.Log("I died");
			StartCoroutine(Revive());
        }

        if (moving)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        if (transform.position.y < -5f)
        {
            transform.position = spawnPoint;
        }

		if (Ghost_Controller.weak) 
		{
			speed = 7.9f;	
		} else if (!Ghost_Controller.weak) {
			speed = 7.5f;
		}

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("GameMaze"))
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
        }

    }
}
