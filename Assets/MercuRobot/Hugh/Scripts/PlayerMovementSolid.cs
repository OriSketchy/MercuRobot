using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSolid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool ceiling = false;

    Animator animator;
    MeltFreeze meltFreeze;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        meltFreeze = GetComponentInParent<MeltFreeze>();
    }


    void Update()
    {
        if (meltFreeze.CanMove())
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
        else
        {
            horizontalMove = 0f;
            jump = false;
        }
        animator.SetBool("Walking", horizontalMove != 0);
        animator.SetBool("Jumping", jump);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
