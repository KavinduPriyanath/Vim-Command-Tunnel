using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHLevel5 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int laserDamage = 10;
    public int shootingEnemyDamage = 10;

    public HB31 healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool laserTouched = false;
    private bool shootingBulletTouched = false;

    public GameObject below30Effect;
    public GameObject damageIndicator;

    public AudioSource hurtSound;

    public int increaseHealth = 70;
    public bool tokenTouched = false;
    public GameObject healthToken;
    public bool isConfirmed = false;

    public GameObject deathMenu;
    public GameObject normalCanvas;

    public AudioSource healthGainSound;

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
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            shootingBulletTouched = true;
        }

        if (other.tag == "Health")
        {
            tokenTouched = true;
        }
    }

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health3");
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(PlayerPrefs.GetInt("health3"));

        script = playerObj.GetComponent<RestLevels>();
    }

    void Update()
    {
        if (closeEnemyTouched == true)
        {
            TakeDamage(closeEnemyDamage);
            closeEnemyTouched = false;
        }

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health4", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health4"));
        }

        if (laserTouched == true)
        {
            TakeDamage(laserDamage);
            laserTouched = false;
        }

        if (shootingBulletTouched == true)
        {
            TakeDamage(shootingEnemyDamage);
            shootingBulletTouched = false;
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
            this.enabled = false;
        }

        if (tokenTouched == true)
        {
            MakeHealth(increaseHealth);
            tokenTouched = false;
            healthToken.SetActive(false);
            isConfirmed = true;
            healthGainSound.Play();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurtSound.Play();
        healthbar.SetHealth(currentHealth);
        StartCoroutine(damageTime());
    }

    void MakeHealth(int increase)
    {
        currentHealth += increase;
        healthbar.SetHealth(currentHealth);
    }

    IEnumerator damageTime()
    {
        damageIndicator.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageIndicator.SetActive(false);
    }
}
