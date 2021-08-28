using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public Transform player;
    public Rigidbody2D rb;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectiles;

    public int maxBossHealth = 500;
    public int currentBossHealth;
    public BossHealthBar healthBar;

    public GameObject deathEffect;

    private bool firstWave = false;
    private bool rest = false;
    private bool secondWave = false;
    private bool thirdWave = false;

    public GameObject shooting1;
    public GameObject shooting2;
    public GameObject secondWaveAppear;
    private LastShootingDeath script1;
    private LastShootingDeath script2;

    public GameObject third1;
    public GameObject third2;
    public GameObject third3;

    private LastShootingDeath sc1;
    private LastShootingDeath sc2;
    private LastShootingDeath sc3;

    private CollisionExplosionEnemy touched1;
    private CollisionExplosionEnemy touched2;
    private CollisionExplosionEnemy touched3;

    public GameObject laserDoor;
    public GameObject levelEnd;

    public AudioSource bossDeath;
    public AudioSource bossShoot;

    void Start ()
    {
        currentBossHealth = maxBossHealth;
        healthBar.SetMaxHealth(maxBossHealth);

        script1 = shooting1.GetComponent<LastShootingDeath>();
        script2 = shooting2.GetComponent<LastShootingDeath>();

        sc1 = third1.GetComponent<LastShootingDeath>();
        sc2 = third2.GetComponent<LastShootingDeath>();
        sc3 = third3.GetComponent<LastShootingDeath>();

        touched1 = third1.GetComponent<CollisionExplosionEnemy>();
        touched2 = third2.GetComponent<CollisionExplosionEnemy>();
        touched3 = third3.GetComponent<CollisionExplosionEnemy>();
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            transform.position = this.transform.position;
        } 
        
        if (firstWave == true)
        {
            if (script1.isDestroyed == false && script2.isDestroyed == false)
            {
                shooting1.SetActive(true);
                shooting2.SetActive(true);
            } else if (script1.isDestroyed == true || script1.isDestroyed == true)
            {
                rest = false;
            }
            
        }

        if (secondWave == true)
        {
            Debug.Log("Saw Appears");
            secondWaveAppear.SetActive(true);
            StartCoroutine(sawDisappear());
        }

        if (thirdWave == true)
        {
            if (sc1.isDestroyed == false && sc2.isDestroyed == false && sc3.isDestroyed == false && touched1.isCollided == false && touched2.isCollided == false && touched3.isCollided == false)
            {
                third1.SetActive(true);
                third2.SetActive(true);
                third3.SetActive(true);
            } 
        }

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (rest == false)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectiles, transform.position, Quaternion.identity);
                bossShoot.Play();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentBossHealth -= damage;
        healthBar.SetHealth(currentBossHealth);
        if (currentBossHealth <= 350)
        {
            Debug.Log("First Wave Appears");
            firstWave = true;
            rest = true;
        } 
        
        if (currentBossHealth <= 250)
        {
            Debug.Log("Second Wave Appears");
            secondWave = true;
            rest = true;
        }

        if (currentBossHealth <= 100)
        {
            Debug.Log("Third Wave Appears");
            thirdWave = true;
        }

        if (currentBossHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator sawDisappear ()
    {
        yield return new WaitForSeconds(27);
        secondWaveAppear.SetActive(false);
        secondWave = false;
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        bossDeath.Play();
        Destroy(gameObject);
        laserDoor.SetActive(false);
        levelEnd.SetActive(true);

    }

}
