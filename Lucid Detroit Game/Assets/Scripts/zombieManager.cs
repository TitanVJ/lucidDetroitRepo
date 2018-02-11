using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour {
    public int initHealth = 50;
    public int currentHealth;
    public int dmg = 20;
    public float fireRate = 1f;

    string heroBullet = "heroBullet";
    PlayerManager playerManager;

    bool isDead;
    //need player object to eventually get dmg numbers

	// Use this for initialization
	void Start () {
        //check if cur level is dream if so then 1.5x the hp and dmg of zombie
        currentHealth = initHealth;
        //heroBullet = GameObject.FindGameObjectWithTag("heroBullet");
        playerManager = FindObjectOfType<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == heroBullet)
        {
            Debug.Log("ay");
            Debug.Log(playerManager.dmg);
            Destroy(other.gameObject);
            currentHealth -= playerManager.dmg;
            if(currentHealth <= 0 && !isDead)
            {
                Death();
            }

        }
    }

    void Death()
    {
        isDead = true;
        //play death animations and sound
        Destroy(gameObject);
        
    }

}
