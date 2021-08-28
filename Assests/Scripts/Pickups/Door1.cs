using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{

    public bool atDoor = false;
    public Dialogue3 verifykeys;
    public GameObject levelEnd;
    public GameObject Dialogues;
    public GameObject currentText;
    public GameObject redDoor;
    public GameObject greenDoor;
    public GameObject laser;


    void Start ()
    {
        verifykeys = Dialogues.GetComponent<Dialogue3>();
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Player")
        {
            atDoor = true;
        }
    }

    void Update ()
    {
        if (verifykeys.canOpen == true && atDoor == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                levelEnd.SetActive(true);
                currentText.SetActive(false);
                greenDoor.SetActive(true);
                laser.SetActive(false);
                redDoor.SetActive(false);
            }
        }
    }
}
