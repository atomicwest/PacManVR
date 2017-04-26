using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_controller : MonoBehaviour {

    public static bool weak;

    //public List<GameObject> children;

    Dictionary<string, GameObject> childObjs = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject>.KeyCollection keys;

    string[] colors = { "red", "pink", "cyan", "orange" };

    // Use this for initialization
    void Start () {
        weak = false;
        GameObject child;

        //fill the dictionary with children, the ghost and its vulnerable state
        for (int i=0; i<gameObject.transform.childCount; i++)
        {
            child = gameObject.transform.GetChild(i).gameObject;
            childObjs.Add(child.name, child);
        }

        keys = childObjs.Keys;

        /*
        foreach (Transform child in transform)
        {
            Children.Add(child.gameObject);
            childObjs.Add(child.name, child);

        }
        */


    }

    // Update is called once per frame
    void Update () {

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


    }
}
