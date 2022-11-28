using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool gamePause=false;
    public GameObject pauseMenuUI;
    private float escape;
    private bool escapeFlag=false;
    private bool escapeFlag2=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        escape=Input.GetAxisRaw("Cancel");
        if(escape!=0){
            escapeFlag=true;
        }        
        if(escapeFlag){
            if(escape==0){
                escapeFlag2=true;
            }            
        }
        if(escapeFlag && escapeFlag2){
            if(gamePause){
                pauseMenuUI.SetActive(false);
                Time.timeScale=1f;
                gamePause=false;
            }else{
                pauseMenuUI.SetActive(true);
                Time.timeScale=0.00001f;
                gamePause=true;
            }
            escapeFlag=false;
            escapeFlag2=false;
        }
         //oyun sadece resume ile devam eder. escape basılı tutarsan hata almazsın. Sorunsuz açılıp kapanan menü +20 puan.
    }
    public void restart(){
        SceneManager.LoadScene("Oyun",LoadSceneMode.Single);
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gamePause=false;
    }
    public void resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gamePause=false;
    }
}
