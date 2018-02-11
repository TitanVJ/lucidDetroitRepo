using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieManager : MonoBehaviour {
    public int initHealth = 50;
    public int currentHealth;
    public int dmg = 20;

    GameObject heroBullet;
    PlayerManager playerManager;

    //need player object to eventually get dmg numbers

	// Use this for initialization
	void Start () {
        //check if cur level is dream if so then 1.5x the hp and dmg of zombie
        currentHealth = initHealth;
        heroBullet = GameObject.FindGameObjectWithTag("heroBuller");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == heroBullet)
        {

        }
    }
}
