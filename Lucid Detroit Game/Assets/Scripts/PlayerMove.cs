using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    private bool canJump = true;

	// Use this for initialization
	void Start ()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            canJump = false;
        }
    }

    void OnCollisionEnter2D (Collision2D collide)
    {
        if(collide.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}
