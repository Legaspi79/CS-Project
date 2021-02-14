using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabandthrow : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public float throwforce;
    public bool grabbed=false;
    public LayerMask notgrabbed;
    public bool thrown;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist); 
        if(grabbed){
          grabCheck.collider.gameObject.transform.parent = boxHolder;
          grabCheck.collider.gameObject.transform.position = boxHolder.position;
          grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if(Input.GetMouseButtonDown(0)){
             print("pressed");
            if(grabbed){
                print("throwing");
                grabbed = false;
                if(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() !=null){
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x,1)*throwforce;
                   
                    
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
            else if(!grabbed){
                print("grabbing");
                if(grabCheck.collider != null && grabCheck.collider.tag == "box"){
                    grabbed = true;
                    
                }
            }    
        }
        
    }
}
