using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class WorldTimer_Controller : MonoBehaviour {

    public Stopwatch watch = new Stopwatch();

    string timestring;
    string[] timesplit;
    Text text; 

	// Use this for initialization
	void Start () {
        watch.Start();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //UnityEngine.Debug.Log(watch.Elapsed);

        timestring = watch.Elapsed.ToString();
        timesplit = timestring.Split('.');
        text.text = "Time: " + timesplit[0];
	}
}
