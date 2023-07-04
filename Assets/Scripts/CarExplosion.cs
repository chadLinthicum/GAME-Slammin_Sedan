using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion : MonoBehaviour //PlayerController inherits from MonoBehavior, which is a class that's applied to all difference object we create
{
    public GameObject player; // Leave public as this is referenced in the camera
    private Vector3 offset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
