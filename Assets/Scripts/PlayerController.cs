using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //PlayerController inherits from MonoBehavior, which is a class that's applied to all difference object we create
{
    // public Variables
    public float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizonalInput;
    public float forwardInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input 
        horizonalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the car forward or backward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); //At speed per sec

        // Rotates the car based on horizontal input
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizonalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizonalInput);
    }
}
