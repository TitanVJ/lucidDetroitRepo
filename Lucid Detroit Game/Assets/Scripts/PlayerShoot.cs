using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    public GameObject bulletPre;
    public Transform spawnPoint;
    public float bulletSpeed;
    private List<GameObject> bullets = new List<GameObject>();
    private SpriteRenderer playerRenderer;
	private SpriteRenderer bulletRenderer;
	private GameObject goBullets;
	private Rigidbody2D rBody;

    // Use this for initialization
    void Start ()
    {
        bulletSpeed = 0.15f;
		playerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        for(int i = 0; i < bullets.Count; i++)
        {

			goBullets = bullets[i];

            if(goBullets != null)
            {   
                /*if(sRenderer.flipX != true)
                    goBullets.transform.Translate(new Vector3(10, 0) * Time.deltaTime * bulletSpeed);
                else
                    goBullets.transform.Translate(new Vector3(-10, 0) * Time.deltaTime * bulletSpeed);*/

                //Removing bullets that go off screen
                Vector3 bulletScreenView = Camera.main.WorldToScreenPoint(goBullets.transform.position);
                if(bulletScreenView.x >= Screen.width || bulletScreenView.x <= 0)
                {
                    DestroyObject(goBullets);
                    bullets.Remove(goBullets);
                }
            }
        }
	}

	public void shootBullet() {
		
			GameObject bullet = (GameObject)Instantiate(bulletPre, spawnPoint.position, Quaternion.identity);
			bulletRenderer = bullet.GetComponent<SpriteRenderer> ();
			rBody = bullet.GetComponent<Rigidbody2D> ();

			// Instantiate(bullet, transform.position);
			bullets.Add(bullet);  
			
			if (playerRenderer.flipX != true)
				bulletRenderer.flipX = false;
			else
				bulletRenderer.flipX = true;

			if (playerRenderer.flipX != true)
				rBody.velocity += (new Vector2(1000,0) * Time.deltaTime * bulletSpeed);
			else
				rBody.velocity += (new Vector2(-1000,0) * Time.deltaTime * bulletSpeed);


	}
}
