using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class grabandthrow : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public PlatformEffector2D effector;
    public float rayDist;
    public float throwforce;
    public static bool grabbed;
    public LayerMask notgrabbed;
    public static bool thrown;
    
    
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
            if(grabbed){
                if(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>() !=null){
                    thrown = true;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,2)*throwforce;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabbed = false;
                }
            }
            else if(!grabbed){
                if(grabCheck.collider != null && grabCheck.collider.tag == "box"){
                    grabbed = true;
                    thrown = false;
                    Timer.Score+=10;
                }
                
            }    
        }

    }
    
    
}


