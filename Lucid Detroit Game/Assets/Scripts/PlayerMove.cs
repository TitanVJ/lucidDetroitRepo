﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float fallMultiplier = 1.25f;
    public float lowJumpMultiplier = 2.0f;
    private PlayerShoot pShoot;
    private SpriteRenderer mySpriteRenderer;
    public Transform spawnPoint;
	private Vector3 flipPos;
	public float fireRate;
    public Animator animator;



    // Use this for initialization
    void Start ()
    {
		//Gets a RigidBody2D if it isn't found.
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();

        }
		//Assigning values to variables etc.
        rb.freezeRotation = true;
        pShoot = FindObjectOfType<PlayerShoot>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
		spawnPoint = GameObject.Find("barrelTip").GetComponent<Transform>();
		flipPos = spawnPoint.transform.localPosition;
		fireRate = 0.15f;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.A))
			{
				if(mySpriteRenderer.flipX != true)
				flipPos.x = -(flipPos.x);
				spawnPoint.transform.localPosition = flipPos;
			}

			if(Input.GetKeyDown(KeyCode.D))
			{
				if(mySpriteRenderer.flipX != false)
				flipPos.x *= -1;
				spawnPoint.transform.localPosition = flipPos; 
			}


		if(Input.GetKey(KeyCode.A))
        {
            mySpriteRenderer.flipX = true;
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            mySpriteRenderer.flipX = false;
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
			StartCoroutine(attackSpeed());
        }

		if (Input.GetKeyUp(KeyCode.Space))
		{

			StopCoroutine(attackSpeed());
		}

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

	IEnumerator attackSpeed()
	{
		while (Input.GetKey (KeyCode.Space) == true) 
		{
			pShoot.shootBullet ();
			yield return new WaitForSecondsRealtime (fireRate);
		}

	}

}
