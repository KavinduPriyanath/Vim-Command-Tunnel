using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimations;

    public GameObject levelEnd;
    private NextLevel script;

    void Start ()
    {
        script = levelEnd.GetComponent<NextLevel>();
    }

    void Update ()
    {
        if (script.nextLevel == true)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnimations.SetTrigger("end");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
