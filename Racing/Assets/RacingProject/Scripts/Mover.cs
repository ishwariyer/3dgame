using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject WheelObj;
    public float throttle = 10;
    Rigidbody rb;
    WheelCollider wheel;

    private void Start()
    {
        wheel = WheelObj.GetComponent<WheelCollider> () ;
        rb = this.GetComponent<Rigidbody> () ;

    }
    private void FixedUpdate()
    {
        float speed = 0;
        
        if(Input.GetKey (KeyCode.S))
        {
            speed = throttle;

        }
        wheel.motorTorque = speed;
        rb.AddForce(-transform.up * throttle);
    }   


}
