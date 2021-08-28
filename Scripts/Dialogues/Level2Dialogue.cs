using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))
        {
            dialogueBox.SetActive(false);
        }
    }
}
