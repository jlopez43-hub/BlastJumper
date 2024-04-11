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
    private float gunHeat;
    

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Firing");
            Shoot();
        }

        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

       
    }

    void Shoot()
    {
  
        Instantiate(rocketPrefab, FirePoint.position, FirePoint.rotation);

        if (FirePoint)
            if (gunHeat <= 0)
            {
                gunHeat = 0.25f;
                Shoot();
            }
        
    }
}
