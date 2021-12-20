// Implements the working of the brake lights
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLight : MonoBehaviour
{
    public Renderer brake_Light_Render;
    public Material brakeLightsOn;
    public Material brakeLightsOff;

    public void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            brake_Light_Render.material = brakeLightsOn;
        }
        else
        {
            brake_Light_Render.material = brakeLightsOff;
        }
    }
}
