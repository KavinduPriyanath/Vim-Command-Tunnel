using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHLevel6 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //damages of each enemies
    public int closeEnemyDamage = 5;
    public int toxicDamage = 10;
    public int laserDamage = 10;
    public int setGunDamage = 10;

    public HB31 healthbar;

    public GameObject playerObj;
    private RestLevels script;

    private bool closeEnemyTouched = false;
    private bool toxicTouched = false;
    private bool laserTouched = false;
    private bool setGunTouched = false;

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

        if (collisionInfo.gameObject.tag == "Toxic")
        {
            toxicTouched = true;
        }

        if (collisionInfo.gameObject.tag == "Laser")
        {
            laserTouched = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            setGunTouched = true;
        }
    }

    void Start()
    {
        currentHealth = PlayerPrefs.GetInt("health4");
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(PlayerPrefs.GetInt("health4"));

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

        if (setGunTouched == true)
        {
            TakeDamage(setGunDamage);
            setGunTouched = false;
        }

        if (script.healthSet == true)
        {
            PlayerPrefs.SetInt("health5", currentHealth);
            Debug.Log("Your health is " + PlayerPrefs.GetInt("health5"));
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
