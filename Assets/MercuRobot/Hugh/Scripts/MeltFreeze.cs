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
        animator.SetBool("Melted", true);
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
        animator.SetBool("Melted", false);
    }
   
    private void FreezeEnd()
    {
        state = State.Solid;
        solid.SetActive(true);
        liquid.SetActive(false);
        pickUp.enabled = true;
    }

}