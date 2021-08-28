using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int laserDamage = 10;

    public HealthBar healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool laserTouched = false;

    public GameObject below30Effect;
    public GameObject damageIndicator;

    public AudioSource hurtSound;

    public GameObject deathMenu;
    public GameObject normalCanvas;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "CloseEnemy")
        {
            closeEnemyTouched = true;
        }

        if (collisionInfo.gameObject.tag == "Laser")
        {
            laserTouched = true;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        script = playerObj.GetComponent<RestLevels>();
    }

    void Update ()
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

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health"));
        }

        if (currentHealth <= 30)
        {
            below30Effect.SetActive(true);
        } else
        {
            below30Effect.SetActive(false);
        }

        if (currentHealth <= 0)
        {
            deathMenu.SetActive(true);
            normalCanvas.SetActive(false);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurtSound.Play();
        healthbar.SetHealth(currentHealth);
        StartCoroutine(damageTime());
    }

    IEnumerator damageTime ()
    {
        damageIndicator.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageIndicator.SetActive(false);
    }

    
    


}
