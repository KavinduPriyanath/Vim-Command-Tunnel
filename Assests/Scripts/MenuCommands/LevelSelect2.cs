using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect2 : MonoBehaviour
{

    public Animator transitionAnimations;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnimations.SetTrigger("end");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Main Menu");
    }
}
