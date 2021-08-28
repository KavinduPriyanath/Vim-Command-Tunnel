using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovements : MonoBehaviour
{
    public float movingSpeed;
    public float rotationSpeed;
    public Transform shotPoint;
    public GameObject bullet;
    public GameObject secondBullet;
    public Transform secondShotPoint;

    public AudioSource gun1Sound;
    public AudioSource gun2Sound;

    public bool isFired = false;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update ()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float inputMagnitude = Mathf.Clamp01(moveInput.magnitude);
        moveInput.Normalize();

        transform.Translate(moveInput * movingSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (moveInput != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            gun1Sound.Play();
        }

        if (isFired == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(secondBullet, secondShotPoint.position, secondShotPoint.rotation);
                gun2Sound.Play();
                StartCoroutine(terminateFire());
            }
        }

        if (isFired == false)
        {
            StartCoroutine(heavyFire());
        }


    }

    IEnumerator heavyFire ()
    {
        yield return new WaitForSeconds(10);
        isFired = true;
    }

    IEnumerator terminateFire ()
    {
        yield return new WaitForSeconds(0.1f);
        isFired = false;
    }
}
