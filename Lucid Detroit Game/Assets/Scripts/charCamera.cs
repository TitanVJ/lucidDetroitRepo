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
    Vector3 targetPos;

    public float zoomSize = 5;

    //Soberbar sobarBar;

    void Start()
    {
        offsetRight = transform.position - player.transform.position;
        offsetLeft = transform.position + player.transform.position;
        targetPos = transform.position;
        offsetX = new Vector3(3f, 0f, 0f);

        //sobarBar = getcomponent<Soberbar>();
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

        /*
        if(){
        
            resolutionChange();
        
        }        
        */
    }
    /*
    void zoomIn()
    {
        GetComponent<Camera> ().orthographicSize = zoomSize-1;
    }
    */
    /*
    void resolutionChange(){

        if(soberBar.alcoholMeter >= 0.2 && soberBar.alcoholMeter < 0.35){
            
        }
        else if (soberBar.alcoholMeter >= 0.35 && soberBar.alcoholMeter < 0.45){

        }
        else if (soberBar.alcoholMeter >= 0.45 && soberBar.alcoholMeter < 0.65){

        }
        else if (soberBar.alcoholMeter >= 0.65 && soberBar.alcoholMeter < 0.77){

        }
        else if (soberBar.alcoholMeter >= 0.77 && soberBar.alcoholMeter < 1.00){

        }



    }
    */
}
