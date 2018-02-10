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
   
    //Soberbar sobarBar;

    void Start()
    {
        offsetRight = transform.position - player.transform.position;
        offsetLeft = transform.position + player.transform.position;
        targetPos = transform.position;
        offsetY = new Vector3(0f, 1.39f, 0f);
        offsetX = new Vector3(3f, 0f, 0f);

        //sobarBar = getcomponent<Soberbar>();
    }

    void FixedUpdate()
    {
        if (player && Input.GetKey(KeyCode.D))
        {
            Vector3 targetCamPos = player.transform.position + offsetRight + offsetX;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, 2f * Time.deltaTime)        ;
        }
        else if (player && Input.GetKey(KeyCode.A))
        {
            Vector3 targetCamPos = player.transform.position + offsetLeft + 2*offsetY - offsetX;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, 2f * Time.deltaTime);
        }
        /*
        if(){
        
            resolutionChange();
        
        }        
        */
    }
    /*
    void resolutionChange(){

        if(soberBar >= 0.2 && soberBar < 0.35){
            
        }
        else if (soberBar >= 0.35 && soberBar < 0.45){

        }
        else if (soberBar >= 0.45 && soberBar < 0.65){

        }
        else if (soberBar >= 0.65 && soberBar < 0.77){

        }
        else if (soberBar >= 0.77 && soberBar < 1.00){

        }



    }
    */
}
