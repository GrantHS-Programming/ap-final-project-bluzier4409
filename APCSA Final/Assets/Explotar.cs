using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Explotar : MonoBehaviour
{
    Rigidbody rb;
    public GameObject target;
    void Awake()
    {
        target = GameObject.FindWithTag("Player");
        rb = target.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        rb.AddExplosionForce(10f, transform.position, 10f, 1f, ForceMode.Impulse);
        Destroy(this);
    }
}
