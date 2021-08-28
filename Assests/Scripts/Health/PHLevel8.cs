using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHLevel8 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int laserDamage = 5;
    public int trapDamage = 5;
    public int stationaryEnemyDamage = 10;

    public HB31 healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool trapTouched = false;
    private bool laserTouched = false;
    private bool stationaryBulletTouched = false;

    public GameObject below30Effect;
    public GameObject damageIndicator;

    public AudioSource hurtSound;

    public GameObject deathMenu;
    public GameObject normalCanvas;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "CloseEnemy")
        {
            closeEnemyTouched = true;
        }

        if (collisionInfo.gameObject.tag == "Laser")
        {
            laserTouched = true;
        }

        if (collisionInfo.gameObject.tag == "Traps")
        {
            trapTouched = true;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            stationaryBulletTouched = true;
        }
    }

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health6");
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(PlayerPrefs.GetInt("health6"));

        script = playerObj.GetComponent<RestLevels>();
    }

    void Update()
    {
        if (closeEnemyTouched == true)
        {
            TakeDamage(closeEnemyDamage);
            closeEnemyTouched = false;
        }

        if (laserTouched == true)
        {
            TakeDamage(laserDamage);
            laserTouched = false;
        }

        if (trapTouched == true)
        {
            TakeDamage(trapDamage);
            trapTouched = false;
        }

        if (stationaryBulletTouched == true)
        {
            TakeDamage(stationaryEnemyDamage);
            stationaryBulletTouched = false;
        }

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health7", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health7"));
        }

        if (currentHealth <= 30)
        {
            below30Effect.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            deathMenu.SetActive(true);
            normalCanvas.SetActive(false);
            this.enabled = false;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurtSound.Play();
        healthbar.SetHealth(currentHealth);
        StartCoroutine(damageTime());
    }

    IEnumerator damageTime()
    {
        damageIndicator.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageIndicator.SetActive(false);
    }
}
