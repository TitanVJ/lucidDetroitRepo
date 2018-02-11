using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    public GameObject enemyPrefab;
    public GameObject groundPlane;

    public float spawnY = -2f;

    private Vector3 _spawnBounds;
    public GameObject playerObj;


    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        if(groundPlane != null)
        {
            MeshRenderer mr = groundPlane.GetComponent<MeshRenderer>();
            if(mr != null)
            {
                _spawnBounds = mr.bounds.extents;
                Debug.Log("SpawnBoudns: " + _spawnBounds);
            }

        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightControl))
        {
            SpawnEnemy();
        }
	}

    public void SpawnEnemy()
    {
        if(enemyPrefab != null)
        {
            GameObject clone = Instantiate(enemyPrefab, FindSpawnPosition(), Quaternion.identity);


            Enemy en = clone.GetComponent<Enemy>();
            en.playerObj = playerObj;
        }
    }


    private Vector3 FindSpawnPosition()
    {
        Vector3 pos = groundPlane.transform.position;

        float randX = Random.Range(-_spawnBounds.x, _spawnBounds.x);
        Vector3 randOffset = new Vector2(randX, spawnY);

        pos += randOffset;

        return pos;
    }
}
