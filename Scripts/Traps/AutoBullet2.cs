using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet2 : MonoBehaviour
{
    public float speed;

    private Transform Trap;
    private Vector2 desPoint;
    private bool setDestroyed = false;

    public GameObject playerHitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            setDestroyed = true;
            Instantiate(playerHitEffect, transform.position, transform.rotation);
        }
    }

    void Start()
    {
        Trap = GameObject.FindGameObjectWithTag("Gun3Set").transform;
        desPoint = new Vector2(Trap.position.x, Trap.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPoint, speed * Time.deltaTime);

        if (setDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
