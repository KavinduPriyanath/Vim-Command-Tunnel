using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPickup : MonoBehaviour
{

    private bool key1touched = false;
    public GameObject key1;
    public GameObject currentText;
    public GameObject keyColor;
    public GameObject nextKey;
    public TMP_Text keypicked;
    public GameObject keyCountvisible;
    public GameObject pickUpEffect;

    public AudioSource yellowPicked;
    public Transform desPoint;
    public int speed = 10;

    private bool toDes = false;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            key1touched = true;
        }
    }

    void Update ()
    {
        if (key1touched == true && Input.GetKeyDown(KeyCode.D))
        {
            //key1.SetActive(false);
            toDes = true;
            currentText.SetActive(false);
            yellowPicked.Play();
            Instantiate(pickUpEffect, transform.position, transform.rotation);
            keyColor.SetActive(true);
            nextKey.SetActive(true);
            keyCountvisible.SetActive(true);
            keypicked.GetComponent<TMP_Text>().text = "1";
        }

        if (toDes == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPoint.position, speed * Time.deltaTime);
            StartCoroutine(disableScript());
        }
    }

    IEnumerator disableScript ()
    {
        yield return new WaitForSeconds(2);
        this.enabled = false;
    }

}
