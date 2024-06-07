using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Explotar : MonoBehaviour
{     Rigidbody rb;
    public GameObject target;

    public ParticleSystem ps;
    void Awake()
    {
        target = GameObject.FindWithTag("Player");
        rb = target.GetComponent<Rigidbody>();
        ps.Stop();
    }
    void OnCollisionEnter(Collision other)
    {
        ps.Play();
        rb.AddExplosionForce(40f, transform.position, 10f, 1f, ForceMode.Impulse);
        Destroy(this);
        Destroy(gameObject, 1f);
    }
}
