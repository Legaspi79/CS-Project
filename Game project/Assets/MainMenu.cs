﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Leaderboard(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
