﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int initHealth = 100;
    public int currentHealth;
    public float drunkLevel; //need a startaing value

    public int dmg = 10;
    public Slider healthBar;
    //assets for anims and audio

    PlayerMove playerMove;
    string enemyBullet = "enemyBullet";
    zombieManager zombieManager;
    string dogManager = "dogManager";

    bool isDead;
    bool damaged;
    
	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
        playerMove = FindObjectOfType<PlayerMove>();
        zombieManager = FindObjectOfType<zombieManager>();
        //dogManager = FindObjectOfType<dogManager>();
	}
	
	// Update is called once per frame
	void Update () {//dmg indicators. update the slider for health
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.tag == "heroBullet")//delete the bullet if it hits the player:: its buggy rn czu it delets rnightwaya at spnw
        //{
        //    Debug.Log("shig");
        //    //Destroy(other.gameObject);

    //}
        if (other.gameObject.tag == enemyBullet)//
        {
            currentHealth -= zombieManager.dmg;
        }
         if (other.gameObject.tag == dogManager)
        {
            Debug.Log("doge");
            currentHealth -= other.transform.parent.gameObject.GetComponent<dogManager>().dmg;
        }

         if(other.gameObject.tag == "vodka")
        {
            Debug.Log("blyatt");
            //do the tthings
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tequila")
        {
            Debug.Log("blyatt");
            //do the tthings
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "jager")
        {
            Debug.Log("blyatt");
            //do the tthings
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "water")
        {
            Debug.Log("blyatt");
            //do the tthings
            Destroy(other.gameObject);
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
