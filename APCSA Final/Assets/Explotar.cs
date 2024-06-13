using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Explotar : MonoBehaviour
{     Rigidbody rb;
    public GameObject target;

    LayerMask blowuppable;

    public ParticleSystem ps;
    void Awake()
    {
        target = GameObject.FindWithTag("Player");
        rb = target.GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        ps.Play();
        rb.AddExplosionForce(25f, transform.position, 10f, 0.5f, ForceMode.Impulse);
        Destroy(this);
        Destroy(gameObject, 1f);
    }
}
