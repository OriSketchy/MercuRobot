using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLiquid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;

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
        }
        else
        {
            horizontalMove = 0f;
        }          
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, true, false);
        rb.gravityScale = !controller.Grounded ? 1 : 10;
    }
}