using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue3 : MonoBehaviour
{

    public GameObject currentText;
    public GameObject nextText;
    public GameObject key1;
    private NormalKeys sc;
    public bool canOpen = false;
    public GameObject bluekeyColor;
    public GameObject replaceEffect;

    public AudioSource bluePicked;

    void Start ()
    {
        sc = key1.GetComponent<NormalKeys>();
    }

    void Update ()
    {
        if (sc.canJoin == true)
        {
           if (Input.GetKeyDown(KeyCode.R))
            {
                currentText.SetActive(false);
                Instantiate(replaceEffect, transform.position, transform.rotation);
                nextText.SetActive(true);
                canOpen = true;
                bluekeyColor.SetActive(true);
                bluePicked.Play();
                this.enabled = false;
            }
        }
    }


}
