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

    bool damaged = false;
    bool isDead;
    
	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
        playerMove = FindObjectOfType<PlayerMove>();
        zombieManager = FindObjectOfType<zombieManager>();
        dogManager = FindObjectOfType<dogManager>();
	}
	
	// Update is called once per frame
	void Update () {//dmg indicators. update the slider for health
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == dogManagerTag)
    //    {

    //        damaged = true;
    //        StartCoroutine(attackSpeed());
    //    }
    //}
    IEnumerator attackSpeed()
	{

        while (!isDead)
        {
            currentHealth -= dogManager.dmg;
            yield return new WaitForSecondsRealtime(dogManager.fireRate);
            damaged = false;
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == enemyBullet)//
        {
            currentHealth -= zombieManager.dmg;
        }

         if (other.gameObject.tag == dogManagerTag)
        {
            Debug.Log("doge");
            //currentHealth -= dogManager.dmg;
            StartCoroutine(attackSpeed());
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
        FindObjectOfType<Enemy>().enabled = false;
        Destroy(gameObject);
    }
}
