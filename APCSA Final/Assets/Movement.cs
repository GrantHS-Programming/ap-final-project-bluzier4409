using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    
    Rigidbody rb;
    public LayerMask ground;
    public float playerHeight;

    public int groundDrag = 4;
    public float airDrag = 0.5f;

    public float maxVel = 2000f;

    public GameObject empty;

    private float velocity;

    public Camera c;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
   void Update()
   {
        dragChange();
        jump();
        wKey();
        aKey();
        sKey();
        dKey();
        dash();
        velocityCap();
   }

   void velocityCap()
   {
    velocity = rb.velocity.magnitude;
    if (velocity > 2000)
    {
        rb.velocity = rb.velocity.normalized * 2000;
    }
   }
    

    void wKey() 
    {
        if (Input.GetKey(KeyCode.W) && grounder()) 
        {
            rb.AddForce(c.transform.forward * 6, ForceMode.Force);
        } 
        else if (Input.GetKey(KeyCode.W)) 
        {
            rb.AddForce(transform.forward * 0.3f, ForceMode.Force);
        }
    }

    void jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounder()) 
        {
            rb.AddForce(Vector3.up * 25, ForceMode.Impulse);
            rb.AddForce(c.transform.forward * .5f, ForceMode.Impulse);
        }
    }

    void dKey() 
    {
        if (Input.GetKey(KeyCode.D) && grounder()) 
        {
            rb.AddForce(c.transform.right * 3, ForceMode.Force);
        } 
        else if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(c.transform.right * 0.3f, ForceMode.Force);
        }
    }

    void sKey()
    {
        if (Input.GetKey(KeyCode.S) && grounder()) 
        {
            rb.AddForce(c.transform.forward * -3, ForceMode.Force);
        } 
        else if (Input.GetKey(KeyCode.S)) 
        {
            rb.AddForce(c.transform.forward * -0.3f, ForceMode.Force);
        }
    }

    void aKey() 
    {
        if (Input.GetKey(KeyCode.A) && grounder()) 
        {
            rb.AddForce(c.transform.right * -3, ForceMode.Force);
        } 
        else if (Input.GetKey(KeyCode.A)) 
        {
            rb.AddForce(c.transform.right * -0.3f, ForceMode.Force);
        }
    }

    void dash()
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            rb.drag = 3;
            rb.AddForce(c.transform.forward * .5f, ForceMode.Impulse);
        }
    }

    void dragChange() 
    {
        if (grounder()) 
        {
            rb.drag = groundDrag;
        } else {
            rb.drag = airDrag;
        }
    }

    bool grounder()
    {
        return Physics.Raycast(empty.transform.position, Vector3.down, (playerHeight * 0.5f) + 0.5f, ground);
    }
}
