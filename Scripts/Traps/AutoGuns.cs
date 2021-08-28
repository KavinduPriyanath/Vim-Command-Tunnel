using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGuns : MonoBehaviour
{

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectiles;
    public AudioSource setGunShot;

    void Update ()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectiles, transform.position, Quaternion.identity);
            setGunShot.Play();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
