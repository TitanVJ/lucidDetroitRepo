using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int initHealth = 100;
    public int currentHealth;
    public Slider healathBar;
    //assets for anims and audio

    PlayerMove playerMove;
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

    public void takeDamage(int dmgAmount)
    {
        //damaged = true;
        currentHealth -= dmgAmount;
        healathBar.value = currentHealth;

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
