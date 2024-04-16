using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//AUthor: LeVassar, Leland
//Purpose: Controling enemy bullet logic such as deleting upon hitting walls

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float speed = 20f;

    private void Awake()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + gameObject.tag);
        Destroy(this.gameObject);
    }
}
