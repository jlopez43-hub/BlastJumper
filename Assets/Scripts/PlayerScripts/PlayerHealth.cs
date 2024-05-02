using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: LeVassar, Leland
//Purpose: Controls player health, damage taking logic, and respawning logic
//Date: 4/9/2024

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Player;
    public Transform RespawnPoint;
    public Transform newRespawnPoint;
    

    private float durationTimer;
    //assigned health bar - J
    public HealthBar healthBar;

  
    private void Awake()
    {
        newRespawnPoint = RespawnPoint;
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        //test code to see if the health bar goes down when health goes down
        //if (Input.GetKeyDown(KeyCode.E))
        //{
           //Debug.Log("Test Damage Triggered");
            //TakeDamage(20);
        //}

        if(currentHealth <= 0)
        {
            Debug.Log("Respawning");
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

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Checkpoint")
        {
            newRespawnPoint = collider.gameObject.transform;
            //Test log to see if transform is correctly assigned
            Debug.Log("Transform collected " + gameObject.transform);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damaged for " + damage);
        
        //Set it to health bar - J
        healthBar.SetHealth(currentHealth);
        durationTimer = 0;
     
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
        Player.transform.position = newRespawnPoint.position;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
