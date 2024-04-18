using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Judith Lopez
 * creating rocket 
 * 03/12/2024
 */

public class Rocket : MonoBehaviour
{
    public GameObject expl;
    public float explForce = 40f;
    public float radius = 2f;
    public Rigidbody rb;
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float explTime = 0.2f;

    private void Awake()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter (Collision collision)
    {
        GameObject _expl = Instantiate(expl, transform.position, transform.rotation);
        Destroy(_expl, explTime);
        knockBack();
        Destroy(gameObject);
    }

    public void knockBack()
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, radius);
        foreach (var obj in surroundingObjects)
        {
            Debug.Log(obj);
            var rb = obj.GetComponent<Rigidbody>();
            Debug.Log(rb);
            if (rb == null) continue;

            rb.AddExplosionForce(explForce, transform.position, radius);

        }
        GameObject _expl = Instantiate(expl, transform.position, transform.rotation);
        Destroy(_expl, explTime);
        Destroy(gameObject);
    }
}
