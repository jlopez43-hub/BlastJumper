using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: LeVassar, Leland
//Purpose: Control Enemy behavior and shooting logic. Currently logic is to lock on to player's
//transform and fire a projectile. 
//Date created: 04/15/2024

public class EnemyShooting : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private float shootInterval = 5f;
    //[SerializeField] private float bulletSpeed = 20f;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform firePoint;

    private void FixedUpdate()
    {
        //Test with adding a pseudo detection range?

        //look at player at all times
        this.gameObject.transform.LookAt(Player);
        //calls function to shoot at player
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        //BUG: ENEMY SHOOTS TWO BULLETS AT ONCE
        //mostly just timer for the shooting and some test code. 
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = shootInterval;

        GameObject bulletObj = Instantiate(enemyBullet, firePoint.transform.position, firePoint.transform.rotation);
        //For some reason the bulletObj gets instantiated twice. 
        Debug.Log("ShootPlayer Triggered");
        //Rigidbody bulletRigid = bulletObj.GetComponent<Rigidbody>();
        //bulletRigid.AddForce(bulletRigid.transform.forward * bulletSpeed);
        Destroy(bulletObj, 5f);
    }
}
