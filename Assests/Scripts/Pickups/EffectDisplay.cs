using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisplay : MonoBehaviour
{

    public GameObject bluePicked;
    public GameObject PlayerObj;
    private RestLevels script;
    public Transform player;
    public GameObject yellowPicked;

    public AudioSource bluePickedSound;
    public AudioSource yellowPickedSound;

    void Start ()
    {
        script = PlayerObj.GetComponent<RestLevels>();
    }

    void Update ()
    {
        if (script.keycount >= 2)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Instantiate(bluePicked, player.position, player.rotation);
                bluePickedSound.Play();
                this.enabled = false;
            }
        }

       
        if (script.key1 == 1 && Input.GetKeyDown(KeyCode.D))
        { 
            Instantiate(yellowPicked, player.position, player.rotation);
            yellowPickedSound.Play();
        }

        if (script.key2 == 1 && Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(yellowPicked, player.position, player.rotation);
            yellowPickedSound.Play();
        }
        
        

    }


}
