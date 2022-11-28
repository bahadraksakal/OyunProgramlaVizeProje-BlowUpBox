using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCollision : MonoBehaviour
{
    public GameObject box;
    void OnCollisionEnter2D(Collision2D blockCollide){
            if(blockCollide.collider.name == "ball"){
                Destroy(box,0);
            }
    }
}
