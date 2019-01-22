using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variable that allows access to the gameObject player
    public GameObject player;
    //allows turnming on and off of vertical follow
    public bool disableVerticalFollow;
    //sets a number for the offset on the horizontal axis
    public float horizontalOffset = 0.0f;
    //sets a number for the offset on the vertical axis
    public float verticalOffset = 0.0f;

    void LateUpdate()
        //this late update function lets us control our camera, if the player is not around it will stick to the x of the player and add the horizontal offset
        //we set the camera to follow the player on the x axis and to our set number on the y axis for the offset
        //if we set our disable vertical follow to true, it will trace the camYPos transform
        //else it will follow the player y + the vertical offset which we will also set in the inspector
        //we then make an instance of the transform.position with a new vector 3 which holds camXPos, camYPos and the transform.position.x
    {
        if (player != null)
        {
            float camXPos = player.transform.position.x + horizontalOffset;
            float camYPos;

            if (disableVerticalFollow == true)
            {
                camYPos = transform.position.y;
            }
            else
            {
                camYPos = player.transform.position.y + verticalOffset;
            }
            transform.position = new Vector3(camXPos, camYPos, transform.position.z);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
        //this update function allows us to set that the camera will follow the player completely, it will leave the character in the center no matter what movement we make
    {
        if (disableVerticalFollow)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
}
