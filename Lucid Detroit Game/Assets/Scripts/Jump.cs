using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity = 6.0f;
    private bool canJump = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Input.GetKey(KeyCode.W) && canJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            canJump = false;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}
