﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text MyScoreText;
    public int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScoreText = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
        MyScoreText.text = "Score:" + ScoreNum;
    }

    // Update is called once per frame
    void Update(){
        MyScoreText.text = "Score:" + Timer.Score;
    }
}
