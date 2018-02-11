using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public int initHealth = 100;
    public int currentHealth;

    public int dmg = 10;
    public Slider healthBar;
    //assets for anims and audio

    PlayerMove playerMove;
    string enemyBullet = "enemyBuller";
    zombieManager zombieManager;
    dogManager dogManager;

    bool isDead;
    bool damaged;
    
	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
       // enemyBullet = GameObject.FindGameObjectWithTag("enemyBullet");
        playerMove = FindObjectOfType<PlayerMove>();
        zombieManager = FindObjectOfType<zombieManager>();
        dogManager = FindObjectOfType<dogManager>();
	}
	
	// Update is called once per frame
	void Update () {//dmg indicators. update the slider for health
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == enemyBullet)//
        //{
        //    currentHealth -= zombieManager.dmg;
        //}
         if (other.gameObject == dogManager)
        {
            currentHealth -= dogManager.dmg;
        }

        //check if dead
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //play death anims and sounds
        playerMove.enabled = false;

        //maybe add particle effect later
        //for now just have destroy
        Destroy(gameObject);
    }
}
