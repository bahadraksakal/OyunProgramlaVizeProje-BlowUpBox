using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed = 4.8f;
    public bool start=true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
                    start=false;
        }

        if(!start){
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(x,0,0);
        }
        if(GameObject.Find("ball")==null){
                    start=true;
        }
    }
}
