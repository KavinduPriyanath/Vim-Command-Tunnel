using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public Transform player;
    public Rigidbody2D rb;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectiles;

    public AudioSource shootingSound;

    void Update ()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            transform.position = this.transform.position;
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (timeBtwShots <= 0)
        {
            Instantiate(projectiles, transform.position, Quaternion.identity);
            shootingSound.Play();
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
