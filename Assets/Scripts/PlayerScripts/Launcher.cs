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
    public float rocketForce;
    public float firerate;
    float nextfire;
    

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        if(Time.time>nextfire)
        {
            nextfire = Time.time + firerate;

            GameObject rocket = Instantiate(rocketPrefab, FirePoint.position, FirePoint.rotation);
            rocket.GetComponent<Rigidbody>().AddForce(FirePoint.right * rocketForce, ForceMode.Impulse);
        }

        


    }
}
