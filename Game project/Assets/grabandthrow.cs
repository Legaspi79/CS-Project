using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabandthrow : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public PlatformEffector2D effector;
    public float rayDist;
    public float throwforce;
    public static bool grabbed;
    public LayerMask notgrabbed;
    public bool thrown;
    public static int Score = 0;
    // Update is called once per frame


    void Update()
    {
        
        
        
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist); 
        
        if(grabbed && grabCheck.collider.tag == "box"){
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //effector.rotationalOffset = 0;
        }
        // else if(!grabbed){
        //     effector.rotationalOffset = 180;
        // }
            

        if(Input.GetMouseButtonDown(0)){
            
             print("pressed");
            if(grabbed){
                print("throwing");
                if(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() !=null){
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x-1,3)*throwforce;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabbed = false;
                    thrown = true;
                }
            }
            else if(!grabbed){
                if(grabCheck.collider != null && grabCheck.collider.tag == "box"){
                    print("grabbing");
                    grabbed = true; 
                    thrown = false; 
                    Score+=1;
                }
                
            }    
        }

    }
}
