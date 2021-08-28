using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelEnd : MonoBehaviour
{
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            SceneManager.LoadScene("Last Screen");
        }
    }

}
