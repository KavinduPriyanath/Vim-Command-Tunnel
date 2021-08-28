using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBullet : MonoBehaviour
{
    public float speed;

    private Transform Trap;
    private Vector2 desPoint;

  

    void Start()
    {
        Trap = GameObject.FindGameObjectWithTag("Player").transform;
        desPoint = new Vector2(Trap.position.x, Trap.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPoint, speed * Time.deltaTime);
    }
}
