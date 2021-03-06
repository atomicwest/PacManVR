using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost_chase : MonoBehaviour {

    Vector3 heading;
    GameObject pacman;

	public static float speed = 0;
	private float currentspeed;

	//disable all boost variables to fix continue bug
	//private float speedboost = 1;
	//private bool boosted;

    CharacterController controller;
    Vector3 targetRotation;

    Vector3 targetDir;
    float step;
    Vector3 newDir;

    // Use this for initialization
    void Start () {
		currentspeed = speed;
		//boosted = false;
        controller = GetComponent<CharacterController>();

        if (gameObject.name.Contains("red")){
            pacman = GameObject.Find("PacMan_back");
        }
        else
        {
            pacman = GameObject.Find("PacMan_front");
        }
        
    }
	

    void switchTarget()
    {
        if (pacman.name.Contains("back"))
        {
            pacman = GameObject.Find("PacMan_front");
        }
        else
        {
            pacman = GameObject.Find("PacMan_back");
        }
    }

	void OnDestroy() {
		//reset red's speed
		//ghosts should only be destroyed when the level 
		//is reloaded
		/*
		if (gameObject.name.Contains ("red")) {
			if (boosted) {
				speed -= speedboost;
				boosted = false;
			}
		}
		*/
	}

	// Update is called once per frame
	void Update () {

		if (Time.timeSinceLevelLoad > 3) {
			currentspeed = 4;
		}

        if (gameObject.name.Contains("orange"))
        {
            //switch every 5 seconds
            if (Time.realtimeSinceStartup%5 == 0)
            {
                switchTarget();
            }
        }
        else if (gameObject.name.Contains("cyan"))
        {
            //switch every 15 seconds
            if (Time.realtimeSinceStartup%15 == 0)
            {
                switchTarget();
            }
        }

        //Debug.Log(GameObject.Find("Super"));

        //red gets a boost if all super pellets are eaten
		/*
		if (GameObject.Find("Super")==null && gameObject.name.Contains("red"))
        {
			boosted = true;
			speed += speedboost;
        }
        */

        targetDir = pacman.transform.position - transform.position;
        step = currentspeed * Time.deltaTime;
		//step = speed;

        //ghosts will flee if a super pellet is activated
        if (Ghost_Controller.weak)
        {
            newDir = Vector3.RotateTowards(transform.forward, -targetDir, step, 0.0F);
        }
        else
        {
            newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        }
        
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * currentspeed);
    }
}
