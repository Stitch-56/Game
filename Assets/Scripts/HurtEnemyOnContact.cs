using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {
    //allows us to set a number for damage given to the enemy on contact
    public int damageToGive;
    //allows a number for the force added to the player after bouncing on enemies head
    public float bounceOnEnemy;
    //this allows access to a gameobject of class RigidBody2D
    private Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start ()
        //this start funtion gets the transform parent of the component RigidBody2D and sets it on a gameobject we create
    {
        myRigidBody2D = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
        //this funtion allows that if the other tag in the collision is the enemy, it will get the component of the health manager and give damage to the enemy
        //it then will apply a force to the player when he collides with the head of the enemy
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, bounceOnEnemy);
        }
    }

}
