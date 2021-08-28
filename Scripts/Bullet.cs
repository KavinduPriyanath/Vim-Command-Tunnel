using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public int damage;
    //public GameObject player;
    public GameObject hitEffect;
    public GameObject wallHit;
    public GameObject trapHitEffect;

    private GameObject hit;
    private AudioSource hitSound;

    private GameObject hitEnemy;
    private AudioSource hitEnemySound;

    void Start ()
    {
        hit = GameObject.FindGameObjectWithTag("hit");
        hitSound = hit.GetComponent<AudioSource>();

        hitEnemy = GameObject.FindGameObjectWithTag("hitEnemy");
        hitEnemySound = hitEnemy.GetComponent<AudioSource>();
    }

    void Update ()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitinfo)
    {
        EnemyDeath enemy = hitinfo.GetComponent<EnemyDeath>();
        FinalBoss boss = hitinfo.GetComponent<FinalBoss>();
        LastShootingDeath firstWave = hitinfo.GetComponent<LastShootingDeath>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            hitEnemySound.Play();
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        } else if (hitinfo.tag == "Boundary")
        {
            Destroy(gameObject);
            hitSound.Play();
            Instantiate(wallHit, transform.position, transform.rotation);
        } else
        {
            Destroy(gameObject, 3);
        }

        if (hitinfo.tag == "Traps")
        {
            Destroy(gameObject);
            hitSound.Play();
            Instantiate(trapHitEffect, transform.position, transform.rotation);
        }

        if (boss != null)
        {
            boss.TakeDamage(damage);
            hitEnemySound.Play();
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (firstWave != null)
        {
            firstWave.TakeDamage(damage);
            hitEnemySound.Play();
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
