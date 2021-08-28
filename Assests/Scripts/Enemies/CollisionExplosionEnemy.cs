using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExplosionEnemy : MonoBehaviour
{
    public float followSpeed;
    public Transform player;
    public Rigidbody2D rb;

    public GameObject deathEffect;
    public bool isCollided = false;

    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
            isCollided = true;
        }
    }

    void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
