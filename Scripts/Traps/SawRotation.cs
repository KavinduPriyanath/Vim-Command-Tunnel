using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{

    public float rotationSpeed = 25f;

    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed));
    }
}
