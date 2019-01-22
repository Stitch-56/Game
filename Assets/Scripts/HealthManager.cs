using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    //allows us to set a number for the max health of our player
    public int maxPlayerHealth;
    //allows a static number for the health of our player that can be access anywhere through a reference to it
    public static int playerHealth;
    //this allows access to our ui for health so that we can change how much health we have on screen
    Text text;
    //this variable allows access to a gameobject levelmanager with reference to the class LevelManager
    private LevelManager levelManager;
    //bool to set isDead true or false
    public bool isDead;

    // Use this for initialization
    void Start()
        //upon starting, the game will get the text component for our ui and set the player health text to whatever number we set max health to in the inspector
        //we then set the level manager object to reference the class LevelManager
        //sets is Dead to false at the begginning so that we are not dead to begin with
    {
        text = GetComponent<Text>();

        playerHealth = maxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;
    }

    // Update is called once per frame
    void Update()
        //this update function allows us to say if the player health is <= to 0 and isDead is false
        //to set the health to 0
        //trigger our repawn player funtion on the level manager
        //set is dead to true
        //and afterwards update the health to 0 on ui
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }
        text.text = "" + playerHealth;
    }

    public static void HurtPlayer(int damageToGive)
        //this static funtion allows the hurt player to be access anywhere
        //this sets the player health to takeaway whatever damage was given
    {
        playerHealth -= damageToGive;
    }

    public void FullHealth()
        //this function allows us to reset the health upon respawn back to full
    {
        playerHealth = maxPlayerHealth;
    }
}
