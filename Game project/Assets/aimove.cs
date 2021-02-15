
using System.Timers;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimove : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    public Collider2D present;
    public Collider2D player; 
    // Update is called once per frame
    void Update()
    {
        if(player.IsTouching(present) && grabandthrow.grabbed == true){
            print("touching");
            speed = 5;
        }else{
            speed = 0;
        }
        if(MoveRight){
            transform.Translate(1 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (1,1);
        }
        else{
            transform.Translate(-1 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (-1,1);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("turn")){
            if(MoveRight){
                MoveRight = false;
            }
            else{
                MoveRight = true;
            }
        }
    }
}
