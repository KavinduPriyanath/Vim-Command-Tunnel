using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHLevel3 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int setGunDamage = 10;
    public int trapDamage = 8;
    public int laserDamage = 10;

    public HB31 healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool setGunTouched = false;
    private bool trapTouched = false;
    private bool laserTouched = false;

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

        if (collisionInfo.gameObject.tag == "Traps")
        {
            trapTouched = true;
        }

        if (collisionInfo.gameObject.tag == "Laser")
        {
            laserTouched = true;
        }

    }

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.tag == "Bullet")
        {
            setGunTouched = true;
        }
    }

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health1");
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(PlayerPrefs.GetInt("health1"));

        script = playerObj.GetComponent<RestLevels>();
    }

    void Update()
    {
        if (closeEnemyTouched == true)
        {
            TakeDamage(closeEnemyDamage);
            closeEnemyTouched = false;
        }

        if (setGunTouched == true)
        {
            TakeDamage(setGunDamage);
            setGunTouched = false;
        }

        if (trapTouched == true)
        {
            TakeDamage(trapDamage);
            trapTouched = false;
        }

        if (laserTouched == true)
        {
            TakeDamage(laserDamage);
            laserTouched = false;
        }

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health2", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health2"));
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
