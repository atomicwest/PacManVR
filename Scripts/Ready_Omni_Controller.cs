using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to READY! text at the start of the game, then make disappear after 20 seconds

public class Ready_Omni_Controller : MonoBehaviour {    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.timeSinceLevelLoad > 20)
        {
            gameObject.SetActive(false);
        }

	}
}
