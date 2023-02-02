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

    private void Start()
    {
        pickUp = gameObject.GetComponent<ObjectPickUp>();
        Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Melt"))
        {
            Melt();
        }
        else if (Input.GetButtonUp("Melt") && !ceiling)
        {
            Freeze();
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
            if (IsMelted() && !Input.GetButton("Melt"))
            {
                Freeze();
            }
        }
    }

    private bool IsMelted()
    {
        return liquid.activeInHierarchy;
    }

    private bool IsFrozen()
    {
        return !IsMelted();
    }

    private void Melt()
    {
        solid.SetActive(false);
        liquid.SetActive(true);
        pickUp.Drop();
        pickUp.enabled = false;
    }

    private void Freeze()
    {
        solid.SetActive(true);
        liquid.SetActive(false);
        pickUp.enabled = true;
    }
}