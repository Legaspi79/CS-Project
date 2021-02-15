using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool muted = false;

    public void Awake()
    {
        if (AudioListener.pause == true)
        {
            muted = true;
        }
    }

    public void ToggleMusic()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
    }
}
