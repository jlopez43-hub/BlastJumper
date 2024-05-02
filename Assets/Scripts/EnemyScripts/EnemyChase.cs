using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy will detect and follow the player

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;

    //enemy detection
    public float detectionRadius = 10f;
    private bool playerInRange = false;

    


    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerInRange = true;
                player = collider.gameObject;
                break;
            }
        }

        if (playerInRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

    }
}
