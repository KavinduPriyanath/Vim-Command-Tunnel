using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHLevel7 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int toxicDamage = 5;
    public int trapDamage = 5;
    public int laserDamage = 5;
    public int stationaryGunDamage = 10;

    public HB31 healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool laserTouched = false;
    private bool trapTouched = false;
    private bool toxicTouched = false;
    private bool stationaryGunToucehd = false;

    public GameObject below30Effect;
    public GameObject damageIndicator;

    public AudioSource hurtSound;

    public int increaseHealth = 70;
    public bool tokenTouched = false;
    public GameObject healthToken;
    public bool isConfirmed = false;

    public GameObject deathMenu;
    public GameObject normalCanvas;

    public AudioSource healthPickUpSound;

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

        if (collisionInfo.gameObject.tag == "Toxic")
        {
            toxicTouched = true;
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
            stationaryGunToucehd = true;
        }

        if (other.tag == "Health")
        {
            tokenTouched = true;
        }
    }

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health5");
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(PlayerPrefs.GetInt("health5"));

        script = playerObj.GetComponent<RestLevels>();
    }

    void Update()
    {
        if (closeEnemyTouched == true)
        {
            TakeDamage(closeEnemyDamage);
            closeEnemyTouched = false;
        }

        if (toxicTouched == true)
        {
            TakeDamage(toxicDamage);
            toxicTouched = false;
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

        if (stationaryGunToucehd == true)
        {
            TakeDamage(stationaryGunDamage);
            stationaryGunToucehd = false;
        }

        if (tokenTouched == true)
        {
            MakeHealth(increaseHealth);
            tokenTouched = false;
            healthToken.SetActive(false);
            isConfirmed = true;
            healthPickUpSound.Play();
        }

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health6", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health6"));
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
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hurtSound.Play();
        healthbar.SetHealth(currentHealth);
        StartCoroutine(damageTime());
    }

    void MakeHealth (int increase)
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
