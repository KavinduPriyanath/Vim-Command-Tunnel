using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NormalKeys : MonoBehaviour
{
    public bool key1touched = false;
    public GameObject key1;
    public int keyCount;
    public GameObject nextText;
    public bool canJoin = false;
    public bool keyFound = false;
    public int count;
    public TMP_Text countText;
    public GameObject pickEffect;

    public AudioSource yellowPicked;
    public Transform desPoint;
    public int speed = 10;

    private bool toDes = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            key1touched = true;
        }
    }

    void Update()
    {
        if (key1touched == true && Input.GetKeyDown(KeyCode.D))
        {
            //key1.SetActive(false);
            toDes = true;
            yellowPicked.Play();
            Instantiate(pickEffect, transform.position, transform.rotation);
            keyCount++;
            countText.GetComponent<TMP_Text>().text = "2";

        }

        if (toDes == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPoint.position, speed * Time.deltaTime);
            StartCoroutine(disableScript());
        }

        if (keyCount == 1)
        {
            nextText.SetActive(true);
            canJoin = true;
            
        }        
    }

    IEnumerator disableScript()
    {
        yield return new WaitForSeconds(2);
        this.enabled = false;
    }
}
