using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: LeVassar, Leland
//Purpose: COntrol Enemy behavior and shooting logic
//Date created: 04/15/2024

public class EnemyShooting : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private float shootInterval = 5;
    //[SerializeField] private float bulletSpeed = 10;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform firePoint;

    private void Update()
    {
        //look at player at all times
        this.gameObject.transform.LookAt(Player);
        //calls function to shoot at player
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        //mostly just timer for the shooting and some test code. 
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = shootInterval;

        GameObject bulletObj = Instantiate(enemyBullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        //Rigidbody bulletRigid = bulletObj.GetComponent<Rigidbody>();
        //bulletRigid.AddForce(bulletRigid.transform.forward * bulletSpeed);
    }
}
