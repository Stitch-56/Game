using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {
    //sets a number for the amount of damage to give to the player
    public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
        //this funtion allows that if the other collision in this is the player
        //to trigger the heallth manager for the player and give the damage to the player
        //it also triggers an audio source to play upon getting hit
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
            other.GetComponent<AudioSource>().Play();
        }
    }
}
