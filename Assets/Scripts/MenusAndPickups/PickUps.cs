using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author [Judith Lopez]
 * Date: 04/17/2024
 * Creating health pickups for when the player is low on health
 */

public enum PickupTypes { HEALTH } // can add more values

public class PickUps : MonoBehaviour
{
    public PickupTypes pickup;

    public float myValue;

    public float rotAngle = 20;

    void Start()
    {


    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotAngle * Time.deltaTime, 0), Space.Self);
    }


 
}
