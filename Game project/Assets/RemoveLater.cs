using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLater : MonoBehaviour
{
    public Transform Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y+12f<Cam.position.y){
            Destroy(gameObject);
        }
    }
}
