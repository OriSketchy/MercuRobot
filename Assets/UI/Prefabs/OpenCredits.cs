using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCredits : MonoBehaviour
{
    [SerializeField]
    GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
    }

    // Update is called once per frame
    public void ButtonClicked()
    {
        credits.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            credits.SetActive(false);
        }
    }
}
