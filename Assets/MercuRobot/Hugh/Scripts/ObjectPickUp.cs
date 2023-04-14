#define USE_JOINT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerMask;

    private void Start()
    {
        int layerIndex = LayerMask.NameToLayer("Objects");
        layerMask = 1 << layerIndex;
        //layer "Objects" is stored as an integer (private int layerIndex) for better performance
    }

    void Update()
    {
        if (EmptyHanded())
        {
            GameObject inRange = ObjectInRange();
            if (Keyboard.current.spaceKey.wasPressedThisFrame && inRange)
            {
                Grab(inRange);
            }
        }
        //release object
        else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Drop();
        } 
    }

    private bool EmptyHanded()
    {
        return grabbedObject == null;
    }

    private GameObject ObjectInRange()
    {
        Vector3 right = transform.right * transform.localScale.x;
        right.Normalize();

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position,
            right, rayDistance, layerMask);
        if (hitInfo.collider != null)
        {
            Debug.DrawRay(rayPoint.position, right * rayDistance, Color.green);
            return hitInfo.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(rayPoint.position, right * rayDistance, Color.red);
            return null;
        }
    }

    private void Grab(GameObject grab)
    {
        Debug.Assert(grabbedObject == null);
        grabbedObject = grab;
        Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        grabbedObject.transform.position = grabPoint.position;
        grabbedObject.transform.SetParent(transform);
    }

    public void Drop()
    {
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
        }
    }
}