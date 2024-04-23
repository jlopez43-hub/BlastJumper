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

    public void Start()
    {
        //initializing health
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
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
