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
    public Slider drunkBar;
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
        //healthBar = GameObject.FindGameObjectWithTag("healthBar");
        //drunkBar = GameObject.FindGameObjectWithTag("drunkBar");
	}

    // Update is called once per frame
    private void Update () {//dmg indicators. update the slider for health
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
	//healthBar.value = currentHealth;
	//drunkBar.value = drunkLevel;
    }
    
    IEnumerator attackSpeed()
	{

        while (!isDead)
        {
            currentHealth -= dogManager.dmg;
            yield return new WaitForSecondsRealtime(dogManager.fireRate);
            damaged = false;
        }

	}

    IEnumerator buff(int i)
    {
        if(i == 1)
        {
            //power buff revert
            yield return new WaitForSecondsRealtime(5f);
            dmg = 10;
        }
        else
        {
            //speed buff revert
            yield return new WaitForSecondsRealtime(5f);
            playerMove.fireRate = 0.15f;
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
            StartCoroutine(attackSpeed());
        }

         if(other.gameObject.tag == "vodka" )//gives you attack speed
        {
            playerMove.fireRate = 0.1f;
            StartCoroutine(buff(0));

            if(drunkLevel + 25 < 100) {
                drunkLevel += 25;
                Debug.Log(drunkLevel);
            }
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tequila" )//gives you health
        {
            currentHealth += 5;

            if (drunkLevel + 20 < 100)
            {
                drunkLevel += 20;
            }
            
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "jager")//gives you power
        {
            dmg = 20;
            StartCoroutine(buff(1));

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
