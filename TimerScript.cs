using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public Parachute_Logic parachute_Logic;
    public Text driveText;
    public Text counterText;
    public float startingTime = 15f;
    public GameObject carObject;

    // Update is called once per frame
    void Update()
    {
        
        startingTime -= Time.deltaTime;
        
        
        if(carObject.transform.position.z > 680)
        {
            driveText.text = null;
        }
        if(startingTime <= 0)
        {
            if(parachute_Logic.isParachuteOpen || parachute_Logic.isGrounded)
            {
                counterText.text = null;
            }
            else if(carObject.transform.position.z > 680)
            {
                startingTime = 0;
                counterText.text = "Open Parachute by hitting space key, Open Now!";
                counterText.fontSize = 48;
            }
            else
            {
                startingTime = 0;
            }
        }
        else
        {
            counterText.text = "Open Parchute in : " + Mathf.Floor(startingTime);
        }
    }
}
