using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogManager : MonoBehaviour
{
    public int initHealth = 20;
    public int currentHealth;
    public int dmg = 5;
    public float fireRate = 0.5f;

    GameObject heroBullet;
    GameObject player;
    PlayerManager playerManager;

    bool isDead;
    //need player object to eventually get dmg numbers

    // Use this for initialization
    void Start()
    {
        //check if cur level is dream if so then 1.5x the hp and dmg of zombie
        currentHealth = initHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        heroBullet = GameObject.FindGameObjectWithTag("heroBullet");
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == heroBullet)
        {
            currentHealth -= playerManager.dmg;
            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }

        }
        if (other.gameObject == player)//need on exist to stop this animation
        {
            //play attacking animation and sounds
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
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
