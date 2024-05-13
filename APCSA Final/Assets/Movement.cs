using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 blah = new Vector3(0,0,0);
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            rb.AddForce(rb.transform.forward * 300, ForceMode.Force);
        }
    }
}
