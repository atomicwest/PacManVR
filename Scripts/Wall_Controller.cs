using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_animation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //from http://answers.unity3d.com/questions/914923/standard-shader-emission-control-via-script.html

        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.blue; 
        //Color baseColor = new Color(23, 79, 55);

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);

        //gameObject.GetComponent<Renderer>().material.color = new Color(233, 79, 55);
    }
}
