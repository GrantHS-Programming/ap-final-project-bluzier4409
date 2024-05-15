using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 blah = new Vector3(50,50,50);
    Rigidbody rb;
    public LayerMask ground;
    public float playerHeight;

    public int groundDrag = 7;

    public float maxVel = 20f;

    public GameObject empty;

    public Camera c;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        wKey();
        aKey();
        sKey();
        dKey();
    }

    void wKey() 
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.AddForce(c.transform.forward * 3, ForceMode.Force);
        }
    }

    void jump() 
    {
        print(grounder());
        if (Input.GetKeyDown(KeyCode.Space) && grounder()) 
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }

    void dKey() 
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(c.transform.right * 3, ForceMode.Force);
        }
    }

    void sKey()
    {
        if (Input.GetKey(KeyCode.S)) 
        {
            rb.AddForce(c.transform.forward * -3, ForceMode.Force);
        }
    }

    void aKey() 
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            rb.AddForce(c.transform.right * -3, ForceMode.Force);
        }
    }

    bool grounder()
    {
        return Physics.Raycast(empty.transform.position, Vector3.down, playerHeight, ground);
    }
}
