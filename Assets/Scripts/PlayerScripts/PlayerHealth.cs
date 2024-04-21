using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: LeVassar, Leland
//Purpose: Controls player health, damage taking logic, and respawning logic
//Date: 4/9/2024

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Player;
    public Transform RespawnPoint;
    //REMEMBER TO CONNECT TO HEALTH BAR

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //test code to see if the health bar goes down when health goes down
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Test Damage Triggered");
            TakeDamage(20);
        }

        if(currentHealth <= 0)
        {
            Respawn();  
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Hazard")
        {
            TakeDamage(20);
        }
        if (collider.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damaged for " + damage);
    }

    private void Respawn()
    {
        Player.transform.position = RespawnPoint.position;
        currentHealth = maxHealth; 
    }
}
