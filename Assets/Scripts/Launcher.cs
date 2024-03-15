using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Judith Lopez
 * Firing from launcher
 * 3/12/2024
 */

public class Launcher : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject rocketPrefab;
    public Rigidbody rb;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Firing");
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(rocketPrefab, FirePoint.position, FirePoint.rotation);
    }
}
