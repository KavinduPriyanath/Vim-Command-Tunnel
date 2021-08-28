using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2 : MonoBehaviour
{

    public GameObject currentText;
    public GameObject nextText;

    private bool escDown = false;

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escDown = true;
        }

        if (Input.GetKeyDown(KeyCode.I) && escDown  == true)
        {
            currentText.SetActive(false);
            nextText.SetActive(true);
            this.enabled = false;
        }

    }
}
