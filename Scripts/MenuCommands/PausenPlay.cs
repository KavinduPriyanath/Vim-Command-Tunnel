using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausenPlay : MonoBehaviour
{
    private bool gameIsPaused;

    public GameObject PauseScreen;
    public GameObject blackBoxes;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Resume();
            } else if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Quit without Saving!!!");
                Application.Quit();
            } else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Saving!!!");
            } 
        }
    }


    void Pause()
    {
        PauseScreen.SetActive(true);
        blackBoxes.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void Resume()
    {
        PauseScreen.SetActive(false);
        blackBoxes.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

}
