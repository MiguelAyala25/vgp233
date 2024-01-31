using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private string keycode;

    private HingeJoint2D hinge;
    private JointMotor2D motor;
    

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
    }

    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            if(keycode == "left")
            {
                ApplyTorque(-torque);
            }
            else if(keycode == "right") 
            {
                ApplyTorque(torque);
            }
        }
        else if (Input.GetKeyUp(keycode))
        {
            if (keycode == "left")
            {
                ApplyTorque(torque);
            }
            else if (keycode == "right")
            {
                ApplyTorque(-torque);
            }
        }
    }

    void ApplyTorque(float torque)
    {
        motor.motorSpeed = torque;
        motor.maxMotorTorque = math.abs(torque);
        hinge.motor = motor; //this tells the engine there is a new setting for the motor
        hinge.useMotor = true; 
    }
}
