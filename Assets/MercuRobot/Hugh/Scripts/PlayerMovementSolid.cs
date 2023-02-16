using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSolid : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool melt = false;
    bool ceiling = false;

    Animator animator;
    //private string currentState;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    //void ChangeAnimationState(string newState)
    //{
    //    //stop the same animation from interrupting itself
    //    if (currentState == newState) return;
    //}

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetBool("Walking", horizontalMove != 0);

        if (Input.GetButtonDown("Jump") && !melt)
        {
            animator.SetBool("Jumping", jump = true);
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, melt, jump);
        animator.SetBool("Jumping", jump = false);
        jump = false;
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
            if (melt && !Input.GetButton("Melt"))
            {
                melt = false;
            }
        }
    }
}
