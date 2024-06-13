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
    
    [Header ("Components")]
    Rigidbody rb;
    GameObject Orientation;
    public CapsuleCollider capsuleCollider;
    Bounds bounds;
    public Camera c;
    
    [Header ("Fixed Values")]
    float playerHeight = 1f;
    int maxRecursions = 5;
    float skinWidth = 0.015f;

    [Header ("Layers")]
    public LayerMask ground;
    public LayerMask layerMask;

    [Header ("Properties")]
    Vector3 playerVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   void Update()
   {
        bounds = capsuleCollider.bounds;
        bounds.Expand(-2 * skinWidth);
    
        changeMove(playerVel);
   }

   Vector3 WASD()
   {
     return Vector3.zero;
   }
    bool grounder()
    {
        return Physics.Raycast(Orientation.transform.position, Vector3.down, (playerHeight * 0.5f) + 0.5f, ground);
    }

    public Vector3 CollideAndSlide(Vector3 vel, Vector3 pos, int depth)
    {
        if (depth >= maxRecursions)
        {
            return Vector3.zero;
        }

        float dist = vel.magnitude + skinWidth;

        RaycastHit hit;

        if (Physics.SphereCast(pos, bounds.extents.x, vel.normalized, out hit, dist, layerMask))
        {
            Vector3 snapToSurface = vel.normalized * (hit.distance - skinWidth);
            Vector3 leftover = vel - snapToSurface;

            if (snapToSurface.magnitude <= skinWidth) {
                snapToSurface = Vector3.zero;
            }

            float mag = leftover.magnitude;
            leftover = Vector3.ProjectOnPlane(leftover, hit.normal).normalized;
            leftover *= mag;

            return snapToSurface + CollideAndSlide(leftover, pos + snapToSurface, depth + 1);
        }

        return vel;
    }

    public void changeMove(Vector3 moveAmount)
    {
       moveAmount = CollideAndSlide(moveAmount, transform.position, 0);
       moveAmount += CollideAndSlide(new Vector3(0,30,0), transform.position + moveAmount, 0);
    }
}
