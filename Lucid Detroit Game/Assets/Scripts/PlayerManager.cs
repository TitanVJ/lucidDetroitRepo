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
    zombieManager zombieManager;
    dogManager dogManager;

    bool isDead;
    bool damaged;
    
	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
        playerMove = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {//dmg indicators. update the slider for health
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == zombieManager)
        {

        }
        else if (other.gameObject == dogManager)
        {

        }
    }


    public void takeDamage(int dmgAmount)
    {
        //damaged = true;
        currentHealth -= dmgAmount;
        healthBar.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //play death anims and sounds
        playerMove.enabled = false;
    }
}
