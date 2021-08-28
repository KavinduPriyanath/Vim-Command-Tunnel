using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public GameObject restartColor;
    public GameObject quitColor;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            restartColor.SetActive(true);
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            quitColor.SetActive(true);
            Application.Quit();
        }
    }

}
