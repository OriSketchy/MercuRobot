using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLiquid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    // Update is called once per frame
    //Get input from player
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //if (Input.GetButtonDown("Melt"))
        //{
        //    crouch = true;
        //}
        //else if (Input.GetButtonUp("Melt"))
        //{
        //    crouch = ceiling;
        //}
    }

    //Update is called a fixed amount of times per second
    //Apply input from player
    void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, true, false);

        //Multiplying by Time.fixedDeltatime ensures that the player moves the same amount no matter how often this function is called
        //jump = false; reverts jump back to Not currently happening so the player only jumps once and then stops jumping 
    }
}