using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{   
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed;
    private List<GameObject> bullets = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        bulletSpeed = 3f;
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
                goBullets.transform.Translate(new Vector3(1, 0) * Time.deltaTime * bulletSpeed);

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
