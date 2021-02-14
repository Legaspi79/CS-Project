using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platform,transform.position,platform.transform.rotation);
        Instantiate(player,transform.position,platform.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
{
    // this basically does FindObjectWithTag("Main camera")
    
    //implement later spawn object within the camera, might use this to destroy when off camera
    var camera = Camera.main.transform;
   
    Instantiate(platform, camera.position + camera.forward * 10f, Quaternion.identity);
}
}
