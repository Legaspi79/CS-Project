using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float seconds;
    public float timer =0.0f;
    public static bool gameOver = false;
    public static int Score;
    // Update is called once per frame
    void Start(){
        Score = 0;
    }
    void Update()
    {
        if(grabandthrow.grabbed){
            timer =0.0f;
            seconds = 0;
        }
         print(seconds);
             if(seconds > 3){
                GameOver(Score);
            }
            if(grabandthrow.thrown){
                timer += Time.deltaTime;
                seconds = timer % 60;
            }
    }

    public void GameOver(int xscore){
    PlayerPrefs.SetInt("Score",xscore);
    SceneManager.LoadScene("GameOver");
    }
    
}
