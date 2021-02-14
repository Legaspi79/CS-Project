using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Timers;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimove : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    
    // Update is called once per frame
    void Update()
    {
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
