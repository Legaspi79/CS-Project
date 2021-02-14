using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabandthrow : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public float throwforce;
    public bool grabbed;
    public LayerMask notgrabbed;
    public bool thrown;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist); 
        
        if(grabbed && grabCheck.collider.tag == "box"){
            try{
            grabCheck.collider.gameObject.transform.parent = boxHolder;
            grabCheck.collider.gameObject.transform.position = boxHolder.position;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }catch(Exception e){
                print(e);
            }
        }
            

        if(Input.GetMouseButtonDown(0)){
            
             print("pressed");
            if(grabbed && grabCheck.collider.tag == "box"){
                print("throwing");
                if(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() !=null){
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x,3)*throwforce;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbed = false;
                    grabCheck.collider.gameObject.transform.parent = null;
                }
            }
            else if(!grabbed){
                
                if(grabCheck.collider != null && grabCheck.collider.tag == "box"){
                    print("grabbing");
                    grabbed = true;   
                }
                
            }    
        }

    }
}
