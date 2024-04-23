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

    //assigned health bar - J
    public HealthBar healthBar; 

    private void Awake()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //test code to see if the health bar goes down when health goes down
        //if (Input.GetKeyDown(KeyCode.E))
        //{
           //Debug.Log("Test Damage Triggered");
            //TakeDamage(20);
        //}

        if(currentHealth <= 0)
        {
            Respawn();  
        }
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            TakeDamage(50);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(20);
        }
        if(collision.gameObject.tag == "Pickup")
        {
            RestoreHealth(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damaged for " + damage);
        
        //Set it to health bar - J
        healthBar.SetHealth(currentHealth);
    }

    public void RestoreHealth(int heal)
    {
        currentHealth += heal;
        Debug.Log("Heal for" + heal);

        healthBar.SetHealth(currentHealth);

        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }


    private void Respawn()
    {
        Player.transform.position = RespawnPoint.position;
        currentHealth = maxHealth; 
    }
}
