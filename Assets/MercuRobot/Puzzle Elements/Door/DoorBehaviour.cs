using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    [SerializeField] bool isDoorOpen = false;
    [SerializeField] bool isLocked = false;
    [SerializeField] bool autoLock = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    [SerializeField] [Range(1,100)]float doorSpeed = 10f;

    public void Lock()
    {
        isLocked = true;
    }
    public void Unlock(DoorKey key)
    {
        if (key != null)
        {
            isLocked = false;
        }

    }

    public void Open()
    {
        if (!isLocked)
        {
            isDoorOpen = true;
        }
    }

    public void Close()
    {
        isDoorOpen = false;
        if (autoLock)
        {
            isLocked = true;
        }
    }
    public void Toggle()
    {
        isDoorOpen = !isDoorOpen;
    }


    // Start is called before the first frame update
    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
        }
        else if (!isDoorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if(transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorSpeed * Time.deltaTime);
        }
    }
}