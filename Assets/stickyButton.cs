using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class stickyButton : MonoBehaviour
{
    void Awake()
    {
        GetComponentInParent<Rigidbody2D>();
        Debug.Log("got rb");
    }

    void Update()
    {
        
    }
}
