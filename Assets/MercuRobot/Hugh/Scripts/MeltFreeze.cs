using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltFreeze : MonoBehaviour
{
    [SerializeField]
    private GameObject solid;
    [SerializeField]
    private GameObject liquid;
    bool ceiling = false;
    ObjectPickUp pickUp = null;

    Animator animator;
    Rigidbody2D rb;

    public enum State
    {
        Solid, 
        Melting, 
        Liquid, 
        Freezing
    }

    State state = State.Solid;

    public State CurrentState { get => state; }

    public bool CanMove()
    {
        return state == State.Solid ||
               state == State.Liquid;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        pickUp = gameObject.GetComponent<ObjectPickUp>();
        rb = GetComponentInParent<Rigidbody2D>();

        FreezeEnd();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Solid:
                if (Input.GetButtonDown("Melt"))
                    MeltStart();
                break;

            case State.Melting:
                break;

            case State.Liquid:
                if (Input.GetButtonDown("Melt") && !ceiling)
                    FreezeStart();
                break;

            case State.Freezing:
                break;
        }

        animator.SetFloat("SpeedX", rb.velocity.x);
        animator.SetFloat("SpeedY", rb.velocity.y);
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
        }
    }

    private void MeltStart()
    {
        state = State.Melting;
        animator.SetTrigger("Melt");
    }
    private void MeltEnd()
    {
        state = State.Liquid;
        solid.SetActive(false);
        liquid.SetActive(true);
        pickUp.Drop();
        pickUp.enabled = false;
    }
    
    private void FreezeStart()
    {
        state = State.Freezing;
        animator.SetTrigger("Freeze");
    }
   
    private void FreezeEnd()
    {
        state = State.Solid;
        solid.SetActive(true);
        liquid.SetActive(false);
        pickUp.enabled = true;
    }

}