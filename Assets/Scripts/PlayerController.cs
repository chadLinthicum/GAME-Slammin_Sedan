using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour //PlayerController inherits from MonoBehavior, which is a class that's applied to all difference object we create
{
    // public Variables
    public float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizonalInput;
    public float forwardInput;
    public float spaceBarCount;
    public Text spaceBarCountText;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HeightTower"))
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceBarCount++;
            if (spaceBarCount == 0)
            {
                spaceBarCountText.text = "MPH: 000";
            }
            else if (spaceBarCount != 0 && spaceBarCount < 10)
            {
                spaceBarCountText.text = "MPH: 00" + spaceBarCount;
            }
            else
            {
                spaceBarCountText.text = "MPH: " + spaceBarCount;
            }
        }



        transform.Translate(Vector3.forward * Time.deltaTime * spaceBarCount); //At speed per sec


        // This is where we get player input 
        //horizonalInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");

        // Moves the car forward or backward based on vertical input


        // Rotates the car based on horizontal input
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizonalInput);
        //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
    }
}