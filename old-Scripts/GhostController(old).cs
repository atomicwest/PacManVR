using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * the red ghost, Blinky, doggedly pursues Pac-Man; 
 * the pink ghost, Pinky, tries to ambush Pac-Man by moving parallel to him; 
 * the cyan ghost, Inky, tends not to chase Pac-Man directly unless Blinky is near; 
 * the orange ghost, Clyde, pursues Pac-Man when far from him, but usually wanders away when he gets close. 
 */


public class GhostController : MonoBehaviour {

    private static float sight = 2.5f;
    private static float speed = 0.5f;
    //private Vector3 translateMod;
    private Vector3 spawnpoint;
    private bool moving = false;

    public static bool weak;

	// Use this for initialization
	void Start () {
        spawnpoint = transform.position;
        weak = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Wall"))
        {
            
        }


    }


    // Update is called once per frame
    void Update () {
        //movement
        //transform.position = transform.position * (1 + speed * Time.deltaTime);
        //transform.position = transform.position + new Vector3(0.1f,0,0);

        //if the player falls in the raycast of the ghost
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(sight, sight, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("GvrMain"))
            {
                
            }
            
            else
            {
                
            }
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnpoint;
        }

    }
}
