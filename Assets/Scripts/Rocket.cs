using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject expl;
    public float explForce, radius;
    public Rigidbody rb;
    [SerializedField]
    private float speed = 20f;
    [SerializedField]
    private float explTime = 0.2f;

    private void Awake()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter (Collision collision)
    {
        GameObject_expl = Instantiate(expl, transform.position, transform.rotation);
        Destroy(_expl, explTime);
        knockBack();
        Destro(gameObject);
    }

    public void knockBack()
    {
        var surroundingObjects = Physics.OverlapSphere(transform.position, radius);
        foreach(var obj in surroundingObjects)
        {
            Debug.Log(obj);
            var rb = obj.GetComponent<Rigidbody>();
            Debug.Log(rb);
            if (rb == null) continue;

            rb.AddExplosionForce(explForce, transform.position, radius);
        }

        GameObject_expl = Instantiate(expl, transform.position, radius);
        Destroy(_expl, explTime);
        Destroy(gameObject);
    }

  
}
