﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToController : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
}
