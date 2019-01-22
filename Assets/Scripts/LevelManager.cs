using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * The LevelManager from the Week 6 Lecture
 */
public class LevelManager : MonoBehaviour {
    //makes a static instance of the levelmanager
    public static LevelManager instance;
    //makes a game object of class LevelManager
    public LevelManager levelManager;
    //sets a gameobject of class gameobject to current checpoint
    public GameObject currentCheckpoint;
    //allows access to a gameobject of the class PlayerController
    private PlayerController player;
    //sets a number for the score the player has
    public int score;
    //sets a gameobject we can manipulate of the death particle
    public GameObject deathParticle;
    //sets a gameobject in the inspector that we can manipulate of the respawn particle
    public GameObject respawnParticle;
    //sets the number for the respawn delay
    public float respawnDelay;
    //sets a gameobject to manipulate called health manager of class HealthManager
    public HealthManager healthManager;
    //private object of cammera follow class
    private CameraFollow camera;

    private void Start()
        //this start funtion finds of the types for PlayerController, CameraFollow and HealthManager so we can reference and use them in our level manager code
    {
        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraFollow>();

        healthManager = FindObjectOfType<HealthManager>();
    }

    private void Update()
    {

    }

    private void Awake()
    {
        // set the instance property/variable to this object
        instance = this;
    }

    public void IncrementScore()
    //used to increment old score system in console for debugging purposes
    {
        score++;
    }
    public void GameScene()
    //allows upon button press access to the Game Scene
    {
        Application.LoadLevel("Game Scene");
    }

    public void MainMenu()
    //allows upon button press access to the Main Menu
    {
        Application.LoadLevel("Main Menu");
    }
    
    public void HowToPlay()
    //allows upon button press access to the How to Play screen
    {
        Application.LoadLevel("How to Play");
    }

    public void QuitGame()
    //allows upon button press to quit the game( build of game only)
    {
        Application.Quit();
    }

    public void RespawnPlayer()
        //this starts the coroutine below for my player respawn
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
        //I used a Couroutine here because i wanted to add a delay time for my code
        //i was using this so i could freeze the code to allow the death animation to play and delay for a second so respawning wasnt instant
        //this allows the player to realise how they died and them jump back into the game
        //first i instantiate the death particle on the player so it plays
        //i then turn off the player so the input controls for the player dont work anymore
        //i then get the renderer component and set it to false so it cant be seen
        //i then start the vertical camera movement so it doesnt keep following the player
        //i then yield a return of a wait for seconds so i can delay the respawn, at which this number for seconds is set in the inspector
        //it then moves the player to the last activated checkpoint transform
        //reenables the player
        //sets renderer back to true
        //uses the healt manager to set the health of the player back to full
        //sets is dead to false
        //sets camera follow in vertical to true again to capture player movements in vertical axis
        //and lastly instantiates the respawn particle to finish animation
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        camera.disableVerticalFollow = false;
        Debug.Log("Player Respawn Here");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        camera.disableVerticalFollow = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D other)
        //this function sets that if the other collision is the player, to sets the checkpoint as a gameobject so that we can access it as our current checkpoint and respawn there
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
        }
    }
}