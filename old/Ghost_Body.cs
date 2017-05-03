using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Body : MonoBehaviour {

    //heading: https://docs.unity3d.com/Manual/DirectionDistanceFromOneObjectToAnother.html

	// Use this for initialization
	void Start () {
		
	}
    
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Portal_Left"))
        {
            //transform.position = GameObject.Find("Portal_Right").transform.position;
            Ghost_Controller.portDir = 1;
        }
        else if (other.name.Contains("Portal_Right"))
        {
            //transform.position = GameObject.Find("Portal_Left").transform.position;
            Ghost_Controller.portDir = 2;
        }
    }
    */
    // Update is called once per frame
    void Update () {
		
	}
}
