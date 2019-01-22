using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // Variable to store the SpriteRenderer 
    private SpriteRenderer theSpriteRenderer;
    // Variable to store the PlayerController
    public PlayerController player;
    // bool to destroy bullet
    private bool seen;
    //Variable to store DeathEffect
    public GameObject enemyDeathEffect;
    //Variable to store ImpactEffect
    public GameObject impactEffect;
    //Int to store pointForKill
    public int pointsForKill;
    //Int for damage
    public int damageToGive;

    // Use this for initialization
    void Start()
    {
        //Finds the SpriteRenderer and allows us to access it
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    //this function allows me to enter the 2D colliders and use them to Instantiate the DeathEffect
    //To destroy the Enemy and to add points to the score.
    //this also lets me set an impact effect for the bullets colliding with walls and platforms
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            Debug.Log("Bullet collided with " + collision.collider.name);

            if (collision.collider.name == "Bullet" || collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
                ScoreManager.AddPoints(pointsForKill);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {

        // Checks to see if the sprite has been made visible on the screen
        // by the SpriteRenderer
        if (theSpriteRenderer.isVisible)
        {
            // sets seen to be true
            
            seen = true;
        }

        // If the sprite (of the bullet) has been displayed but is no longer
        // being displayed then this means it has gone out of view so lets
        // destroy it
        if ((theSpriteRenderer.isVisible == false) && (seen == true))
        {
            Destroy(gameObject);
        }
    }
}
