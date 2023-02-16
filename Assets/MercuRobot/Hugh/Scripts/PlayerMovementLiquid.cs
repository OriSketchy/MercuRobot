using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLiquid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetBool("Walking", horizontalMove != 0);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, true, false);
    }
}