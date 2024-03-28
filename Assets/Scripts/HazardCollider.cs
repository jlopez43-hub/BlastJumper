using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Hazard" tag
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Collided with hazard!");
        }
    }


}
