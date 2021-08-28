using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public bool nextLevel = false;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            nextLevel = true;
        }            
            
    }
}
