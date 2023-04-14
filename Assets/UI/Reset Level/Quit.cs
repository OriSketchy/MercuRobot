using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField]
    Button button;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }



    }
    public void ButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
}