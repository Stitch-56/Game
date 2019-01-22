using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    //lets us set the number to add to our points system in our score manager script
    public int pointsToAdd;
    //this allows access to the audio source on our coin gameobject
    public AudioSource coinSoundEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
        //this allows us to upon triggering the colider of the player and the coin to add points to our score system
        //it also allows us to play our audio source and destroy the game object coin
        //the if statement is to make sure only the object with the player controller script can trigger the coin collider
    {
        if (other.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);

        coinSoundEffect.Play();

        Destroy(gameObject);
    }

}
