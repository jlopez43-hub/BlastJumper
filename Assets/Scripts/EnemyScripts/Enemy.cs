using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author[Judith Lopez and LeVassar, Leland]
 * Date [04/02/2024]
 * Updated by LeVassar, Leland on 4/22
 * Summary:[Holds logic for enemy health and damage taking scripts]
 */

public class Enemy : MonoBehaviour
{
    //event that will trigger upon enemy death. Can possibly be used for multiple purposes
    public static event Action<Enemy> OnEnemyKilled;

    public int maxHealth = 100;
    public int currentHealth;

    //for enemy to drop health pickup
    public GameObject HealthPickup;

    //healthBar for enemy
    public EnemyHealth enemyHealth;


    public void Start()
    {
        //initializing health
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);
        
    }

  
    //Enemy damage
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            //droping health item
            DropItem();

            Debug.Log("Hit Rocket");
            TakeDamage(20);
        }
    }

   private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Explosion")
        {
            Debug.Log("Hit Explosion");
            TakeDamage(10);
        }

    }

    private void DropItem()
    {
        Instantiate(HealthPickup, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    void TakeDamage(int damage)
    {
        //reducing health logic
        currentHealth -= damage;
        //Debug.Log("Enemy Damaged for " + damage);

        enemyHealth.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //Broadcast Enemy killed
            //OnEnemyKilled?.Invoke(this);
        }
    }
}
