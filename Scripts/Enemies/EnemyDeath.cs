using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;

    public bool isDead = false;

    public AudioSource deathSound;


    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <=0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        deathSound.Play();
        Instantiate(deathEffect, transform.position, transform.rotation);
        isDead = true;
    }


}
