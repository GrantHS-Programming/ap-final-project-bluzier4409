using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning : MonoBehaviour
{
    public Transform Position;
    public LayerMask isWall;
    Rigidbody rb;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    bool checkRightWall()
     {
        return Physics.Raycast(Position.position, Position.right, 1f, isWall);
    }

    bool checkLeftWall()
     {
        return Physics.Raycast(Position.position, Position.right * -1, 1f, isWall);
    }

    void applyForce() 
    {
        if (checkLeftWall()) 
        {   
            rb.AddForce(rb.transform.right * -5, ForceMode.Force);
            rb.AddForce(rb.transform.forward * 6, ForceMode.Force);
        }
        else if (checkRightWall()) 
        {
            rb.AddForce(rb.transform.right * 5, ForceMode.Force);
            rb.AddForce(rb.transform.forward * 6, ForceMode.Force);
        }
    }

    void Update()
    {
        print(checkLeftWall());
        applyForce();
    }
}
