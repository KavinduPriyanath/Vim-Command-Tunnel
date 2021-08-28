using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Player : MonoBehaviour
{
    public float movingSpeed;
    public float rotationSpeed;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
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

    }
}
