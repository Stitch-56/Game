using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {
    //this allows access to my particle systems that are attatched to game objects with this script
    private ParticleSystem thisParticleSystem;
	// Use this for initialization
	void Start ()
        //this allows access to the particle sysytem and allows us to use it in functions
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
        //this update function tells the game that if the particle system is playing and plays the one time it will returm amd destroy the particles
    {
        if (thisParticleSystem.isPlaying)
            return;

        Destroy(gameObject);
	}

    private void OnBecameInvisible()
        //this code is to make sure that we destroy the particles if they become invisible
    {
        Destroy(gameObject);
    }
}
