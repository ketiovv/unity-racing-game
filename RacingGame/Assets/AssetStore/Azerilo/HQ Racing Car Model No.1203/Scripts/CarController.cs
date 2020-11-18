using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public InputManager im;
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public float strenghtCoefficent = 10000f;
    public float maxTurn = 20f;
    public Transform CM;
    public Rigidbody rb;
    void Start()
    {
        im = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        if(CM)
        {
            rb.centerOfMass = CM.localPosition;
        }
    }
    void FixedUpdate()
    {
        foreach (var wheel in throttleWheels)
        {
            wheel.motorTorque = strenghtCoefficent * Time.deltaTime * im.throttle; 
        }

        foreach (var wheel in steeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn ,0f);
        }

        foreach (var mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >=0 ? 1: -1) / (2 * Mathf.PI * 0.27f), 0f, 0f);
        }
    }
}
