using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Collision : MonoBehaviour
{
    int maxRecursions = 5;
    float skinWidth = 0.015f;

    Bounds bounds;
    public LayerMask layerMask;

    public CapsuleCollider capsuleCollider;

    void Update()
    {
        bounds = capsuleCollider.bounds;
        bounds.Expand(-2 * skinWidth);
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
}
