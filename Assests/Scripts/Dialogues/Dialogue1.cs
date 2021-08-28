using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue1 : MonoBehaviour
{

    public GameObject currentText;
    public GameObject nextText;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            currentText.SetActive(false);
            nextText.SetActive(true);
            this.enabled = false;

        }
    }
}
