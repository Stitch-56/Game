using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {
    //allows us to access LevelManager game object
    public LevelManager levelManager;

	// Use this for initialization
	void Start ()
        //finds the type levelManager gameobject of the class LevelManager so we can reference from it.
    {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
        //this function allows us to set the checkpoints we have to the transform we made and send a debug log to the console to show activation.
        //it activates the checkpoint through collisions
    {
        levelManager.currentCheckpoint = gameObject;
        Debug.Log("Activated Checkpoint" + transform.position);
    }

}
