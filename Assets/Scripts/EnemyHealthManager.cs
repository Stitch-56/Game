using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    //this allows us to set a number for the enemy health
    public int enemyHealth;
    //this allows access to the gameobject of the death effect particle
    public GameObject deathEffect;
    //this allows us to set a number for the amount of points we get for killing the enemy
    public int pointsOnDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
        //in this update function, if the health of the enemy is 0 or less, it will instantiate the death effect particle on the transform of the player
        //it will then add the points we set in the inspector to the score manager
        //it will then destroy the enemy
    {
		if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
	}

    public void giveDamage(int damageToGive)
        //this funtion allows us to set the amount of damage when the enemey has been killed and to play the audio source on the enemy upon death
    {
        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();        
    }

}
