using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSolid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    float gravityHoldoffDelay = 0.5f;
    float gravityHoldoffEnd = 0;
    Animator animator;
    MeltFreeze meltFreeze;
    Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        meltFreeze = GetComponentInParent<MeltFreeze>();
        rb = GetComponentInParent<Rigidbody2D>();
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
        animator.SetBool("Jumping", jump);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            rb.gravityScale = 1;
            gravityHoldoffEnd = Time.time + gravityHoldoffDelay;
        }
        if (Time.time > gravityHoldoffEnd && controller.Grounded)
        {
            rb.gravityScale = 10;
        }

        jump = false;
    }
}
