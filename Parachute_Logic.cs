using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parachute_Logic : MonoBehaviour
{
    public TimerScript timerScript;
    public  bool isGrounded = false;
    public  bool isParachuteOpen = false;
    public Camera carCamera;
    public Camera parachuteCamera;
    public GameObject parachute1;
    public GameObject parachute2;
    public GameObject parachute3;
    public GameObject car;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && timerScript.startingTime <= 0 && !isGrounded)
        {
            OpenParachute();
        }
        if(car.transform.position.y < 175)
        {
            OnGround();
        }
        if(isParachuteOpen)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                car.transform.Rotate(Vector3.forward*70*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                car.transform.Rotate(Vector3.back*70*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                car.transform.Rotate(Vector3.right*70*Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                car.transform.Rotate(Vector3.left*70*Time.deltaTime);
            }
        }
    }

    public void OpenParachute()
    {
        parachute1.gameObject.SetActive(true);
        parachute2.gameObject.SetActive(true);
        parachute3.gameObject.SetActive(true);
        car.GetComponent<Rigidbody>().drag = 2.2f;
        parachuteCamera.gameObject.SetActive(true);
        carCamera.gameObject.SetActive(false);
        isParachuteOpen = true;
    }

    public void OnGround()
    { 
            parachute1.gameObject.SetActive(false);
            parachute2.gameObject.SetActive(false);
            parachute3.gameObject.SetActive(false);
            car.GetComponent<Rigidbody>().drag = 0;
            carCamera.gameObject.SetActive(true);
            parachuteCamera.gameObject.SetActive(false);
            isGrounded = true;
            isParachuteOpen = false;  
    }
}
