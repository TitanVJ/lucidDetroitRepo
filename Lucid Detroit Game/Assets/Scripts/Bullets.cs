using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public GameObject bullet;
    private float bulletSpeed = 3.0f;
    private List<GameObject> bullets = new List<GameObject>();


	// Use this for initialization
	void Start () {
    
    
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Jump")) {
            bulletRelease();
        }	

        for(int n = 0; n < bullets.Count; n++) {
            GameObject firedBullet = bullets[n];
            if (firedBullet != null) {
                firedBullet.transform.Translate(new Vector2(0,1) * Time.deltaTime * bulletSpeed);
                //destroy function
            }

        }

	}

    void bulletRelease() {
        

        GameObject baseBullet = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
        bullets.Add(baseBullet);


    }
}
