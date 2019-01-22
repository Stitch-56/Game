using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
        //this trigger allows us to upon coliding with our exit at the end of the game, to change the scene to the game over screen
    {
        Application.LoadLevel("Game Over");
    }

}
