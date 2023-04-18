using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Level Loaded");

    }
}
