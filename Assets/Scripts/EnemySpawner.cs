using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    //this variable allows access to the enemy game prefab
    public GameObject enemy;
    //this variable allows acces to the empty game object transform that i will use to spawn the enemies
    public Transform enemyPos;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
        //this collider function allows us to instantiate an enemy prefab on the position of the enemyPos game object upon triggering it
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
    }
}
