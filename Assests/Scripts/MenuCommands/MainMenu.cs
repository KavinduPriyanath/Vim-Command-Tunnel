using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator playAnimator;
    //public Animator saveAnimator;
    public Animator quitAnimator;

    public Animator transitionAnimations;

    public void playGame()
    {
        StartCoroutine(play());
    }

    public void quitGame()
    {
        StartCoroutine(quit());
    }

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playAnimator.SetBool("IsPressed", true);
            playGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            quitAnimator.SetBool("IsPressed", true);
            quitGame();
        }
    }

    IEnumerator play()
    {
        transitionAnimations.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator quit()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
