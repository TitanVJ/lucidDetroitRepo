using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int initHealth = 100;
    public int drunkLevel = 0;
    public int currentHealth;

    public int dmg = 10;
    public Slider healthBar;
    //assets for anims and audio

    PlayerMove playerMove;
    string enemyBullet = "enemyBullet";
    zombieManager zombieManager;
    string dogManagerTag = "dogManager";
    dogManager dogManager;

    bool isDead;
    bool damagedByDog = false;
    
	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
        playerMove = FindObjectOfType<PlayerMove>();
        zombieManager = FindObjectOfType<zombieManager>();
        dogManager = FindObjectOfType<dogManager>();
	}
	
	// Update is called once per frame
	void Update () {//dmg indicators. update the slider for health
        
        if(damagedByDog)
        {
            currentHealth -= dogManager.dmg;

        }
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
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
         if (other.gameObject.tag == dogManagerTag)
        {
            Debug.Log("doge");
            damagedByDog = true;
        }

         if(other.gameObject.tag == "vodka" )
        {
            if(drunkLevel + 25 < 100) {
                drunkLevel += 25;
                Debug.Log(drunkLevel);
            }
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tequila" )
        {
            if (drunkLevel + 20 < 100)
            {
                drunkLevel += 20;
            }
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "jager")
        {
            if (drunkLevel + 15 < 100)
            {
                drunkLevel += 15;
            }
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "water")
        {
            if (drunkLevel - 15 > 0)
            {
                drunkLevel -= 15;
            }
            if (drunkLevel - 15 < 0)
            {
                drunkLevel = 0;
            }
            Destroy(other.gameObject);
        }

        //check if dead
        
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
