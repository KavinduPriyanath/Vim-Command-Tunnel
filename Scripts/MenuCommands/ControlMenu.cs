using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public GameObject controlPanel;
    private bool isActive = false;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isActive == false)
            {
                controlPanel.SetActive(true);
                VisibleCursor();
                isActive = true;
            } else
            {
                controlPanel.SetActive(false);
                InvisibleCursor();
                isActive = false;
            }
        }
    }

    void VisibleCursor ()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void InvisibleCursor ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
