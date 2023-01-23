using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour DoorBehaviour;
    [SerializeField] bool isDoorOpenSwitch;
    [SerializeField] bool isDoorClosedSwitch;
    [SerializeField] float switchSpeed = 0.2f;
    [SerializeField] float switchDelay = 1f;
  
    float switchSizeY;
    Vector3 switchUpPos;
    Vector3 switchDownPos;  float holdOffFinish = 0f;
    bool isPressingSwitch = false;

    enum SwitchState
    {
        Up,
        GoingDown,
        Down,
        HoldOff,
        GoingUp
    };
    SwitchState state = SwitchState.Up;

    void Awake()
    {
        switchSizeY = transform.localScale.y / 2;

        switchUpPos = transform.position;
        switchDownPos = new Vector3(transform.position.x, transform.position.y - switchSizeY, transform.position.z);
    }

    void Update()
    {
        switch(state)
        {
            case SwitchState.Up:
                if (isPressingSwitch) 
                {
                    state = SwitchState.GoingDown;
                }
                break;

            case SwitchState.GoingDown:
                if (MoveSwitchDown())
                {
                    state = SwitchState.Down;
                    if (isDoorOpenSwitch && !DoorBehaviour.isDoorOpen)
                    {
                        DoorBehaviour.isDoorOpen = !DoorBehaviour.isDoorOpen;
                    }
                    else if (isDoorClosedSwitch && DoorBehaviour.isDoorOpen)
                    {
                        DoorBehaviour.isDoorOpen = !DoorBehaviour.isDoorOpen;
                    }                
                }
                break;

            case SwitchState.Down:
                if (!isPressingSwitch)
                {
                    holdOffFinish = Time.time + switchDelay;
                    state = SwitchState.HoldOff;
                }
                break;

            case SwitchState.HoldOff:
                if(Time.time > holdOffFinish)
                {
                    state = SwitchState.GoingUp;
                }
                break;

            case SwitchState.GoingUp:
                if (MoveSwitchUp())
                {
                    state = SwitchState.Up;
                }
                break;
        }
    }

    bool MoveSwitchDown()
    {
        if (transform.position != switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchDownPos, switchSpeed * Time.deltaTime);
            return false;
        }
        else
        {
            return true;
        }
    }
    bool MoveSwitchUp()
    {
        if (transform.position != switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchUpPos, switchSpeed * Time.deltaTime);
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            //could also be written as  if(collision.gameObject.tag == "Player")  but this version is more optimised if ran in a void update for example but doesnt matter in an OnTrigger
        {
            isPressingSwitch = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressingSwitch = false;
        }
    }
}