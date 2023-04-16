using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField]
    Button button;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MercuRobot_UI");
        }



    }
    public void ButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
}