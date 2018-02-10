using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 50.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position);
        }
	}
}
