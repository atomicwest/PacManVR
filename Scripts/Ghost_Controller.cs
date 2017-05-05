using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Controller : MonoBehaviour {

    public static bool weak;
    public static float supertime;
    //public static bool revive;      //this should not be static
    //public static int portDir;      //this should not be static

    private bool revive;
    private int portDir;

    Dictionary<string, GameObject> childObjs = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject>.KeyCollection keys;

    string[] colors = { "red", "pink", "cyan", "orange" };

    //private Vector3 spawnpoint;
    public static Vector3 spawnpoint;

    // Use this for initialization
    void Start () {
        spawnpoint = GameObject.Find("Ghost_Respawn_Point").transform.position;
        weak = false;
        revive = false;
        GameObject child;

        //fill the dictionary with children, the ghost and its vulnerable state
        //the dictionary is used for switching when pacman eats the super pellet
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            child = gameObject.transform.GetChild(i).gameObject;
            childObjs.Add(child.name, child);
        }

        keys = childObjs.Keys;
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

        else if (other.name.Contains("GvrMain") && weak)
        {
            transform.position = spawnpoint;
        }
    }
    

    void Switcher()
    {
        if (weak)
        {
            foreach (string name in keys)
            {
                if (name.Contains("vulnerable"))
                {
                    //Debug.Log("Should switch now");
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
                    //Debug.Log("Not weak anymore");
                    childObjs[name].SetActive(false);
                }
                else
                {
                    childObjs[name].SetActive(true);
                }
            }
        }

        //Debug.Log(supertime);

        if (supertime < 0)
        {
            weak = false;
        }

    }
    
    //delegate the respawn to the pacman controller
    void Respawn()
    {
        if (revive)
        {
            gameObject.transform.position = spawnpoint;
            revive = false;
        }
    }


    // Update is called once per frame
    void Update () {

        Switcher();
        //Respawn();
        //Portals();

    }
}
