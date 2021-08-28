using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public GameObject instructions;
    public GameObject canvas;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            instructions.SetActive(true);
            canvas.SetActive(false);
        }
    }
}
