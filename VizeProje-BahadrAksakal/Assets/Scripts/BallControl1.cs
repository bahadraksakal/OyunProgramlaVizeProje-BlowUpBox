using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallControl1 : MonoBehaviour
{

    private Vector3 mouseVec;
    private bool start=true;
    public GameObject crosshair;
    public GameObject kare;
    public GameObject top;
    public GameObject youWinMenuUI;
    int skor = 0;
    int can = 3;
    public Text skorTxt;
    public Text canTxt;

    public float ballSpeed;
    private float mouse0;
    private bool mouse0Flag=false;

    

    void Update()
    {
        if(start){
            mouseVec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.z));
            crosshair.transform.position = new Vector2(mouseVec.x,mouseVec.y);

            Vector3 fark = mouseVec - top.transform.position;

                mouse0=Input.GetAxis("Fire1");
                if(mouse0!=0){
                    mouse0Flag=true;
                }
                if(can>0 && mouse0Flag){
                    start=false;
                    float uzaklik = fark.magnitude; //fark vektorunun buyuklugu
                    Vector2 yon = fark / uzaklik; //yon vektorunun olusturulmasi
                    yon.Normalize(); //vektor buyuklugu 1'e indirilir. (sadece yon almasi icin)
                    ballMove(yon);
                }
                else if(can==0){
                    SceneManager.LoadScene("Oyun",LoadSceneMode.Single);
                }      
                mouse0=0;
                mouse0Flag=false;          
        }
        
    }
    void ballMove(Vector2 yon){
        GetComponent<Rigidbody2D>().velocity = yon * ballSpeed;
    }
    
    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.name == "yatay_alt"){
            //Destroy(top,0);
            Vector3 pos = new Vector3(0,-3.5f,0);
            Vector3 pos2 = new Vector3(0.01f,-4,0);
            top.transform.position=pos;
            kare.transform.position=pos2;
            GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            can--;
            canTxt.text = "Can: " + can.ToString();
            start=true;
        }
        if(col.collider.tag == "block"){
            skor++;
            skorTxt.text = "Skor: " + skor.ToString();
            if(skor>=16){
                youWinMenuUI.SetActive(true);
                Time.timeScale=0.00001f;
            }
        }
        
    }
    public void youWinMenuRestart(){
        SceneManager.LoadScene("Oyun",LoadSceneMode.Single);
        youWinMenuUI.SetActive(false);
        Time.timeScale=1f;
    }
}
