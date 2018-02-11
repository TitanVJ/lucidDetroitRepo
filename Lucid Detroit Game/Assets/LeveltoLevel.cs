using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveltoLevel : MonoBehaviour
{

    private string elevator = "elevator";
    private string elevator2 = "elevator2";
    private string secondfloor = "secondfloor";
	private string final = "final";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == elevator)
        {
            SceneManager.LoadScene(1);
        }   
        
        if (other.gameObject.tag == elevator2)
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.tag == secondfloor)
        {
            SceneManager.LoadScene(3);
        }

		if(other.gameObject.tag == final){
            SceneManager.LoadScene(4);
        } 
   
    }

}