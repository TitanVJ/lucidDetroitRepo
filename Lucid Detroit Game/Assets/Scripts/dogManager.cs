using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogManager : MonoBehaviour
{
    public int initHealth = 20;
    public int currentHealth;
    public int dmg = 5;
    public float fireRate = 0.5f;

    string heroBullet = "heroBullet";
    string player = "Player";
    PlayerManager playerManager;

    bool isDead;
    //need player object to eventually get dmg numbers

    // Use this for initialization
    void Start()
    {
        //check if cur level is dream if so then 1.5x the hp and dmg of zombie
        currentHealth = initHealth;
        //player = GameObject.FindGameObjectWithTag("Player");
        //heroBullet = GameObject.FindGameObjectWithTag("heroBullet");
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == heroBullet)
        {
            currentHealth -= playerManager.dmg;
            Destroy(other.gameObject);
            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }

        }
        if (other.gameObject.tag == player)//need on exist to stop this animation
        {
            //play attacking animation and sounds
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == player)
        {
            //stop playing attacking animation cuz ur no longer near protag
        }
    }
    void Death()
    {
        isDead = true;
        //play death animations and sound
        Destroy(gameObject);

    }

}
