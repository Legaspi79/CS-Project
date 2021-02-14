using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform box;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(box.position.x,box.position.y,transform.position.z);
    }
}
