using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    protected GameObject player;       //Public variable to store a reference to the player game object


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position =new  Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
