using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    private List<GameObject> bullets = new List<GameObject>();
    private SpriteRenderer sRenderer;

    // Use this for initialization
    void Start ()
    {
        bulletSpeed = 3f;
        sRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(Input.GetKey(KeyCode.Space))
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bulet = (GameObject)Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            // Instantiate(bullet, transform.position);
            bullets.Add(bulet);
        }

        for(int i = 0; i < bullets.Count; i++)
        {
            GameObject goBullets = bullets[i];
            if(goBullets != null)
            {   
                if(sRenderer.flipX != true)
                    goBullets.transform.Translate(new Vector3(1, 0) * Time.deltaTime * bulletSpeed);
                else
                    goBullets.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * bulletSpeed);

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
}
