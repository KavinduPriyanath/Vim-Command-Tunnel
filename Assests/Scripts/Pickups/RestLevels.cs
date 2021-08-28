using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestLevels : MonoBehaviour
{

    public GameObject yellowColored;
    public GameObject blueColored;
    public GameObject keyCountMeter;
    public int key1;
    public int key2;
    public int keycount = 0;
    private bool key1Picked = false;
    private bool key2Picked = false;
    public TMP_Text countDisplay;
    public int allKeys = 2;
    private bool atDoor = false;
    public GameObject levelEnd;
    private bool canAdvanced = false;

    public Transform coin1;
    public Transform coin2;
    public Transform desPoint;
    public float moveSpeed;

    public GameObject redDoor;
    public GameObject greenDoor;
    public GameObject laser;

    public bool healthSet = false;

    public AudioSource laserUnlocked;


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Key1" && key2 == 0)
        {
            key1 = 1;

        } else if (other.tag == "Key1" && key2 == 1)
        {
            key1 = 1;
            key2 = 0;
        } else if (other.tag == "Key2" && key1 == 0)
        {
            key2 = 1;
        } else if (other.tag == "Key2" && key1 == 1)
        {
            key2 = 1;
            key1 = 0;
        }
    }

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Door")
        {
            atDoor = true;
        }
    }

    void Update ()
    {
        if (key1 == 1 && Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Picked key1");
            keycount++;
            key1Picked = true;
            key1 = 0;
        }

        if (key2 == 1 && Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Picked Key2");
            keycount++;
            key2Picked = true;
            key2 = 0;
        }

        if (key1Picked == true)
        { 
            coin1.position = Vector2.MoveTowards(coin1.position, desPoint.position, moveSpeed * Time.deltaTime);
        }

        if (key2Picked == true)
        {
            coin2.position = Vector2.MoveTowards(coin2.position, desPoint.position, moveSpeed * Time.deltaTime);
        }

        if (keycount > 0)
        {
            yellowColored.SetActive(true);
            keyCountMeter.SetActive(true);
            countDisplay.GetComponent<TMP_Text>().text = keycount.ToString();
        }

        if (keycount >= allKeys)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                blueColored.SetActive(true);
                canAdvanced = true;
            }
        }

        if (atDoor == true && canAdvanced == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                levelEnd.SetActive(true);
                laser.SetActive(false);
                laserUnlocked.Play();
                greenDoor.SetActive(true);
                redDoor.SetActive(false);
                healthSet = true;
            }
        }

        
    }

}
