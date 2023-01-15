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

       if (Input.GetButtonDown("Jump"))
       {
            jump = true;
       }

       if(Input.GetButtonDown("Crouch")) 
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
    void FixedUpdate ()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        //Multiplying by Time.fixedDeltatime ensures that the player moves the same amount no matter how often this function is called
        //jump = false; reverts jump back to Not currently happening so the player only jumps once and then stops jumping 
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("Enter " + collision.collider.tag);
        if (collision.collider.tag == "Ceiling")
        {
            ceiling = true;
        }

	}
	private void OnCollisionExit2D(Collision2D collision)
	{
        Debug.Log("Exit " + collision.collider.tag);
        if (collision.collider.tag == "Ceiling")
        {
            ceiling = false;
            if (crouch && !Input.GetButton("Crouch"))
            {
                crouch = false;
            }
        }
    }
}


