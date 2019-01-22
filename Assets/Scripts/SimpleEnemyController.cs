using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    //sets a number for the speed of enemy that we can change in the inspector
    public float speed;
    //sets a number for the patrol distance of the enemy that can be changed in the inspector
    public float patrolDistance;
    //this allows us to set a starting position of the enemy
    private Vector3 startingPosition;
    //allows acces to the rigidbody attatched to the enemy
    private Rigidbody2D theRigidBody;
    //sets a number for the direction of the enemy
    private int direction;
    //checks the transform for the ground check
    public Transform groundCheck;
    //applies a layer mask to platforms to check the ground
    public LayerMask whatIsGround;
    //sets a ground raidius for the enemy so it knows when it is in contact
    public float groundRadius;
    //sets a true or false for being grounded
    private bool grounded;
	// Use this for initialization
	void Start ()
        //sets the starting position of the enemy in the start funtion
        //allows us access to its rigidbody
        //sets the direction to 1 which is right
    {
        startingPosition = gameObject.transform.position;
        theRigidBody = gameObject.GetComponent<Rigidbody2D>();
        direction = 1;
	}
	
	// Update is called once per frame
	void Update ()
        //this sets that if the collider that is collided with is the groundcheck that it sets it to move
        //the next statements set which direction it moves
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        grounded = (bool)colliderWeCollidedWith;
        if ((gameObject.transform.position.x >= startingPosition.x + patrolDistance) && (direction == 1))
        {
            direction = -1;
        }
        else if ((gameObject.transform.position.x <= startingPosition.x -patrolDistance) && (direction == -1))
        {
            direction = 1;
        }
	}
    private void FixedUpdate()
        //this function allows us to set the speed of the x and the y of the enemy
    {
        if (grounded)
        {
            theRigidBody.velocity = new Vector2(speed * direction, theRigidBody.velocity.y);
        }
        else
        {
            theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
        //this funtion allows us to set that if the enemy collides with the enemy that it destroys itself and the bullet
    {
        Debug.Log("Enemy collided with " + collision.collider.name);

        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            // Destroy the Bullet
            Destroy(collision.collider.gameObject);

            // Destroy the Enemy
            Destroy(gameObject);
        }
    }
}
