using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
    //sets a variable to allow access to the level manager game object created form the LevelManager class
    public LevelManager levelmanager;


	// Use this for initialization
	void Start ()
        //this start funtion allows us to the find the class type LevelManager and to set a gameobject instance of it
    {
        levelmanager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D other)
        //this funtion states that if the other collision is tagged player it is to trigger the repspawn player funtion of the player thats on the levelmanager
    {
        if (other.name == "Player")
        {
            levelmanager.RespawnPlayer();
        }
    }
}
