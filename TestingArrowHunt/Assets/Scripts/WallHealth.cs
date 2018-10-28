using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour {

    public int startingWallHealth = 1000;                            // The amount of health the wall starts the game with.
    public int currentWallHealth;
    bool damaged;                                   //To check wall is taking damage or not.
    bool isDead;                                    //To check wall is destroyed or not.
    AudioSource wallHitAudio;
    EnemyMovementScript enemyMove;
    public Animator wallAnim;
    public AudioClip destroyedClip;
    GameObject wallObject;

    // Use this for initialization
    void Awake () {
        currentWallHealth = startingWallHealth;
        wallObject = GameObject.Find("DefenceWall");
    }
	
	// Update is called once per frame
	void Update () {

        if (damaged)
        {
            //Write code for wall animation.
        }

        damaged = false;
	}

    public void TakeWallDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentWallHealth -= amount;
        // Play the hurt sound effect.
        wallHitAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentWallHealth <= 0)
        {
            // ... it should die.
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        Debug.Log("Wall has been destroyed");
        // Turn off any remaining shooting effects.
        enemyMove.DisableEffects();

        // Tell the animator that the wall is destroyed.
        //wallAnim.SetTrigger("isDestroy");
        Destroy(wallObject.gameObject);
        
        // Set the audiosource to play the destroyed clip and play it (this will stop the hurt sound from playing).
        wallHitAudio.clip = destroyedClip;
        wallHitAudio.Play();
    }
}
