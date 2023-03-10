using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool ceiling = false;

    // Update is called once per frame
    //Get input from player
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && !crouch)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = ceiling;
        }
    }

    //Update is called a fixed amount of times per second
    //Apply input from player
    void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        //Multiplying by Time.fixedDeltatime ensures that the player moves the same amount no matter how often this function is called
        //jump = false; reverts jump back to Not currently happening so the player only jumps once and then stops jumping 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ceiling")
        {
            ceiling = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ceiling")
        {
            ceiling = false;
            if (crouch && !Input.GetButton("Crouch"))
            {
                crouch = false;
            }
        }
    }
}