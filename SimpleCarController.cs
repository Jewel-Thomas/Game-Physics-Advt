using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public Parachute_Logic parachute_Logic;
    public Camera mainCamera;
    public Camera sideCamera;
    public Transform car;
    private float m_forwardInput;
    private float m_horizontalInput;
    private float m_steerAngle;

    public WheelCollider wheelBR_W, wheelBL_W;
    public WheelCollider wheelFR_W, wheelFL_W;
    public Transform wheelBR_T,wheelBL_T;
    public Transform wheelFR_T,wheelFL_T;

    public float max_steerAngle = 30.0f;
    public float motorSpeed = 70.0f;
    public float brakeStrength = 1500;
    public Rigidbody carRb;
    public float currentVelocity;

    public void GetInput()
    {
        m_forwardInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");
    }

    private void Steer()
    {
        m_steerAngle = max_steerAngle * m_horizontalInput;
        wheelFR_W.steerAngle = m_steerAngle;
        wheelFL_W.steerAngle = m_steerAngle;
    }

    private void Accelerate()
    {
        if(m_forwardInput < 0)
        {
            m_forwardInput = 0;
        }
        wheelFR_W.motorTorque = m_forwardInput * motorSpeed;
        wheelFL_W.motorTorque = m_forwardInput * motorSpeed;
        wheelBL_W.motorTorque = m_forwardInput * motorSpeed;
        wheelBR_W.motorTorque = m_forwardInput * motorSpeed;
        
    }

    private void Braking()
    {
        Vector3 vel = carRb.velocity;
        if(Input.GetKey(KeyCode.DownArrow))
        {
            carRb.AddForce(-transform.forward*brakeStrength*Time.deltaTime,ForceMode.Acceleration);
        }
    }
    
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelFR_W,wheelFR_T);
        UpdateWheelPose(wheelFL_W,wheelFL_T);
        UpdateWheelPose(wheelBR_W,wheelBR_T);
        UpdateWheelPose(wheelBL_W,wheelBL_T);
    }
    
    private void LimitRotation()
    {
        Quaternion carQuat = car.transform.rotation;
        if(car.transform.rotation.x > 25)
        {
            carRb.freezeRotation = true;
        }
        
    }

    private void UpdateWheelPose(WheelCollider _collider,Transform _tranform)
    {
        Vector3 _pos = _tranform.position;
        Quaternion _quat = _tranform.rotation;

        _collider.GetWorldPose(out _pos,out _quat);

        _tranform.position = _pos;
        _tranform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        Braking();
        LimitRotation();
        if(Input.GetKeyDown(KeyCode.C) && !parachute_Logic.isParachuteOpen)
        {
            mainCamera.enabled = !mainCamera.enabled;
            sideCamera.enabled = !sideCamera.enabled;
        }
    }
}
