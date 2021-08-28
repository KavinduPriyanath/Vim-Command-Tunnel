using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Potion : MonoBehaviour
{
    public GameObject healthPotion;
    public Transform potion;
    public Transform player;
    public EnemyDeath enemy;
    public int speed = 2;

    public PHLevel5 script;

    void Update()
    {
        if (enemy.isDead == true)
        {
            healthPotion.SetActive(true);
            potion.position = Vector2.MoveTowards(potion.position, player.position, speed * Time.deltaTime);


            if (script.tokenTouched == false && script.isConfirmed == true)
            {
                enemy.isDead = false;
                this.enabled = false;
            }
        }
    }
}
