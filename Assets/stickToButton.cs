using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class stickToButton : MonoBehaviour
{
    public GameObject Hugh;
    public GameObject Switch;
    RigidbodyConstraints2D rigidbodyConstraints2D;

    void Start()
    {
        Hugh = GameObject.Find("/Hugh");
        Debug.Log("Found Hugh");
        Switch = GameObject.Find("Switch");
        Debug.Log("Found Switch");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hugh in trigger zone");
            Hugh.transform.parent = Switch.transform;        
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hugh out of trigger zone");
            Hugh.transform.parent = null;
        }    
    }

}
