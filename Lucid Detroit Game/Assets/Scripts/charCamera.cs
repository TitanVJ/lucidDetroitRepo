using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCamera : MonoBehaviour {


    public float cameraSpeed;
    public GameObject player;
    public Vector3 offsetRight;
    public Vector3 offsetLeft;
    private Vector3 offsetY;
    private Vector3 offsetX;
    private int currentDrunkenessLevel = 0;
    //Vector3 targetPos;

    public float zoomSize = 5;

    PlayerManager playerManager;

    void Start()
    {
        offsetRight = transform.position - player.transform.position;
        offsetLeft = transform.position + player.transform.position;
        //targetPos = transform.position;
        playerManager = FindObjectOfType<PlayerManager>();
        offsetX = new Vector3(3f, 0f, 0f);
    }
    void Update() {

        //Drunk Level 0
        if (playerManager.drunkLevel < 15)
        {
            if (currentDrunkenessLevel == 1)
            {
                Debug.Log("currentDrunkenessLevel 0");
                zoomOut();
                currentDrunkenessLevel = 0;
            }
        }
        //Drunk Level 1
        if (playerManager.drunkLevel >= 15 && playerManager.drunkLevel < 35)
        {
            if (currentDrunkenessLevel < 1)
            {
                zoomIn();
            }
            if (currentDrunkenessLevel > 1)
            {
                zoomOut();
            }
            currentDrunkenessLevel = 1;
        }
        //Drunk Level 2
        if (playerManager.drunkLevel >= 35 && playerManager.drunkLevel < 45)
        {
            if (currentDrunkenessLevel < 2)
            {
                zoomIn();
            }
            if (currentDrunkenessLevel > 2)
            {
                zoomOut();
            }
            currentDrunkenessLevel = 2;
        }
        //Drunk level 3
        if (playerManager.drunkLevel >= 45 && playerManager.drunkLevel < 65)
        {
            if (currentDrunkenessLevel < 3)
            {
                zoomIn();
            }
            if (currentDrunkenessLevel > 3)
            {
                zoomOut();
            }
            currentDrunkenessLevel = 3;
        }
        //Drunk Level 4
        if (playerManager.drunkLevel >= 65 && playerManager.drunkLevel < 77)
        {
            if (currentDrunkenessLevel < 4)
            {
                zoomIn();
            }
            if (currentDrunkenessLevel > 4)
            {
                zoomOut();
            }
            currentDrunkenessLevel = 4;
        }
        //Drunk Level 5
        if (playerManager.drunkLevel >= 77 && playerManager.drunkLevel < 100)
        {
            if (currentDrunkenessLevel < 5)
            {
                Debug.Log("currentDrunkenessLevel 5");
                zoomIn();
                currentDrunkenessLevel = 5; 
            }
        }



    }
    void FixedUpdate()
    {
        if (player && Input.GetKey(KeyCode.D))
        {
            //Vector3 targetCamPos = player.transform.position + offsetRight + offsetX;
            Vector3 targetCamPos = new Vector3(player.transform.position.x + offsetRight.x + 3.0f, 0f, -10f);
            transform.position = Vector3.Lerp(transform.position, targetCamPos, 2f * Time.deltaTime);

        }
        else if (player && Input.GetKey(KeyCode.A))
        {
            //Vector3 targetCamPos = player.transform.position + offsetLeft + 2*offsetY - offsetX;
            Vector3 targetCamPos = new Vector3(player.transform.position.x + offsetLeft.x + 3.0f, 0f, -10f);
            transform.position = Vector3.Lerp(transform.position, targetCamPos, 2f * Time.deltaTime);
        }

    }

    void zoomIn()
    {
        zoomSize -= 0.34f;
        GetComponent<Camera> ().orthographicSize = zoomSize;
    }
    void zoomOut()
    {
        zoomSize += 0.34f;
        GetComponent<Camera>().orthographicSize = zoomSize;
    }

    
}
