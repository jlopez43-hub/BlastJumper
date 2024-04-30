using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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

    public float health;
    public float maxHealth = 20;

    //for enemy to drop health pickup
    public GameObject HealthPickup;


    public void Start()
    {
        //initializing health
        health = maxHealth;
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

    public void TakeDamage(float damageAmount)
    {
        //reducing health logic
        health -= damageAmount;
        Debug.Log("Enemy Damaged for " + damageAmount);

        if (health <= 0)
        {
            Destroy(gameObject);
            //Broadcast Enemy killed
            OnEnemyKilled?.Invoke(this);
        }
    }
}
