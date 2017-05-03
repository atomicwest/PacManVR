using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_controller : MonoBehaviour {

    public static bool weak;
    public static float supertime;
    public static bool revive;

    Dictionary<string, GameObject> childObjs = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject>.KeyCollection keys;

    string[] colors = { "red", "pink", "cyan", "orange" };

    private Vector3 spawnpoint;

    // Use this for initialization
    void Start () {
        spawnpoint = GameObject.Find("GhostRespawnPoint").transform.position;
        weak = false;
        revive = false;
        GameObject child;

        //fill the dictionary with children, the ghost and its vulnerable state
        for (int i=0; i<gameObject.transform.childCount; i++)
        {
            child = gameObject.transform.GetChild(i).gameObject;
            childObjs.Add(child.name, child);
        }

        keys = childObjs.Keys;

    }

    void Respawn()
    {
        transform.position = spawnpoint;
        revive = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Portal_Left"))
        {
            transform.position = GameObject.Find("Portal_Right").transform.position;
        }
        else if (other.name.Contains("Portal_Right"))
        {
            transform.position = GameObject.Find("Portal_Left").transform.position;
        }
    }

    
    // Update will revive the ghost 
    // switch and keep ghosts vulnerable if weak==true, vice-versa if otherwise, 
    // decrement supertime if weak == true and
    // change the value of weak when supertime is 0
    void Update () {

        if (revive)
        {
            Respawn();
        }

        if (weak)
        {
            foreach(string name in keys)
            {
                if (name.Contains("vulnerable"))
                {
                    childObjs[name].SetActive(true);
                } 
                else
                {
                    childObjs[name].SetActive(false);
                }
            }

            supertime -= Time.deltaTime;

        }

        else if (!weak)
        {
            foreach (string name in keys)
            {
                if (name.Contains("vulnerable"))
                {
                    childObjs[name].SetActive(false);
                }
                else
                {
                    childObjs[name].SetActive(true);
                }
            }
        }

        if (supertime < 0)
        {
            weak = false;
        }

    }
}
