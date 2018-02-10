using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour {
    public int initHealth = 100;
    public int currentHealth;
        public Slider healthBar;
    //need to add assets for death


    bool isDead;
    bool isDamaged;

    PlayerMove playerMove;

	// Use this for initialization
	void Start () {
        currentHealth = initHealth;
        playerMove = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(int dmgAmnt)
    {
        isDamaged = true;
        currentHealth -= dmgAmnt;
        healthBar.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
            death();

    }
    void death()
    {
        isDead = true;
        //death anim and sounds

        playerMove.enabled = false;
    }
}
