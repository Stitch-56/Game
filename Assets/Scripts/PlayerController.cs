using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //allows private access to the rigid body
    private Rigidbody2D theRigidBody;
    //sets a number for the horizontal speed of the player
    public float horizontalSpeed;
    //is a bool for if jumping is through or false
    public bool doJump;
    //sets a number so we can see how many times we have jumped
    public int inJump;
    //sets a true or false for it we are on the ground
    public bool grounded;
    //sets a number for the radius to detect the ground under the player
    public float groundRadius;
    //sets a masking layer so we know what is the ground and what is not
    public LayerMask whatIsGround;
    //sets a number for hspeed
    public float hSpeed;
    //sets a prefab in the script of the bullet so we can use it in the player code
    public GameObject bulletPrefab;
    //sets a gameobject of the transform of the gun that is parented to the player
    public Transform gun;
    //checks if we are on the ground
    [Tooltip("the point around which we will check are we on the ground")]
    public Transform groundCheck;
    //sets the y force of the jump
    [Tooltip("The y force of the jump")]
    public float jumpForce;
    //true or false for if we are facing right or not
    private bool facingRight;

    // Use this for initialization
    void Start ()
        //gets the compnent of the rigidbody in the start funtion and also sets the facing right bool to true as we are facing right in the beginning
    {
        theRigidBody = GetComponent<Rigidbody2D>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update ()
        //this update funtion sets the key for our jump and sets it to the up arrow key
        {
            doJump = Input.GetKeyDown(KeyCode.UpArrow);


            // Get the value of the "Horizontal! axis, this will be a value between 
            // 1 and -1
            //this allows us to make a game object on the ground check game object parented to the player so that this lets us know we are grounded or not
            float hAxis = Input.GetAxisRaw("Horizontal");

            Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

            grounded = (bool)colliderWeCollidedWith;
        

            // If the value of the horizontal axis in not 0 then the user/player is
            // moving the joystick or pressing the arrow keys either left or right
            //this allows us to make sure that if we are not on the h axis and that we are ground that we can set the flips for our character
            //if the h axis is greater than 0 and not facing right we flip and vice verse
            if (hAxis != 0 && grounded)
            {

                if ((hAxis > 0) && (!facingRight))
                {
                    flip();
                }
                else if ((hAxis < 0) && (facingRight))
                {
                    flip();
                }

                theRigidBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigidBody.velocity.y);

            }
            else if (!grounded)
            {
                theRigidBody.velocity = new Vector2(theRigidBody.velocity.x, theRigidBody.velocity.y);
            }
            else
            {
                theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);

            }
        bool shoot = Input.GetKeyDown(KeyCode.Space);
        //this sets a bool to shoot our weapon and sets it to keycode space

        if (shoot)
            //if the shoot bool is true then it will shoot our bullet prefab with a force that we set
        {
            ShootBullet();
        }

    }

        private void FixedUpdate()
        //in this fixed update funtion we are setting parentheses for if statements
        //in this if we are do a jump and we are grounded and our injump is 0 and or if we do jump and or we have jump less than 2 times
        //it will allow us to jump
        //this enables a double jump feature
        //if our rigidbody.y is set to 0 and we are grounded then it will reset our injump to 0
        {
            if ( (doJump && grounded && (inJump == 0)) || (doJump && (inJump < 2)) )
            {
                Vector2 jf = new Vector2(0, jumpForce);
                theRigidBody.AddForce(jf, ForceMode2D.Impulse);
                inJump++;
            }

            if (theRigidBody.velocity.y == 0 && grounded)
            {
                inJump = 0;
            }
        }

        // This function flips the game object
        void flip()
        {
            // Toggle the value of facingRight i.e. put it equal to what
            // it is not currently
            facingRight = !facingRight;

            // Get a compy of the scale property from the Transporm compnent
            Vector3 theScale = gameObject.transform.localScale;

            // Multiply the x component of scale by -1 to 'flip' it.
            theScale.x *= -1;

            // Store the modified value back
            transform.localScale = theScale;
        }
    private void OnCollisionEnter2D(Collision2D collision)
        //this funtion allows that if the collider is the bullet it will destroy the enemy
    {

            Debug.Log("Player collided with " + collision.collider.name);

            if (collision.collider.name == "Bullet")
            {
                Destroy(collision.gameObject);
            }
    }
    private void ShootBullet()
    {
        /* Instantiate a Bullet. The Instantiate function takes three arguments:
         *  1.  The GameObject that you want to clone (make a copy of). For me I pass in
         *      the bulletObject variable which I set via the inspector to be equal to
         *      the Bullet prefab
         *  2.  The position you want to place this newly cloned object
         *  3.  The rotation of this newly cloned object
         *  
         *  For me, the position and rotation are set to the position and rotation of
         *  the gun which is an empty game object that is a child of the Hero.
         */
        GameObject aBullet = Instantiate(bulletPrefab, gun.position, gun.rotation);

        if (gameObject.transform.localScale.x < 0)
        {
            Vector3 tempLocalScale = aBullet.transform.localScale;
            tempLocalScale.x *= -1;
            aBullet.transform.localScale = tempLocalScale;
        }


        /*
         * Get the RigidBody2D component of this newly created bullet so that I can
         * set it's velocity.
         */

        Rigidbody2D bulletsRigidBody;
        bulletsRigidBody = aBullet.GetComponent<Rigidbody2D>();

        /*
         * Set the velovity to be either +20 or -20 depending on the direction the 
         * Hero is facing.
         */
        if (facingRight)
        {
            bulletsRigidBody.velocity = new Vector2(20, 0);
        }
        else
        {
            bulletsRigidBody.velocity = new Vector2(-20, 0);
        }
    }

}
