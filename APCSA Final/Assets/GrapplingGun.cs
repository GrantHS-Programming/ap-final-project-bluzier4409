using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
  private LineRenderer lr;
  private Vector3 GrapplePoint;

  public LayerMask grappleable;

  public float maxDist;

  private SpringJoint joint;

  public Transform GunTip, CameraHolder, Player;

  public float springForce, damper, massScale;

  void Awake()
  {
    lr = GetComponent<LineRenderer>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
       grapple();
    }
    else if (Input.GetMouseButtonUp(0))
    {
      stopGrapple();
    }
  }

  void LateUpdate()
  {
      draw();
  }

  void grapple()
  {
    RaycastHit hit;
    if (Physics.Raycast(CameraHolder.position, CameraHolder.forward, out hit, maxDist, grappleable))
    {
      if (hit.point != null) 
      {
        GrapplePoint = hit.point;
        joint = Player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = GrapplePoint;

        float distanceFromPoint = Vector3.Distance(Player.position, GrapplePoint);
        joint.maxDistance = distanceFromPoint * 0.8f;
        joint.minDistance = distanceFromPoint * 0.25f;
        joint.spring = springForce;
        joint.damper = damper;
        joint.massScale = massScale;
        lr.positionCount = 2;    
      }
    }
  }

  void draw()
  {
    if (!joint) return;

    else
    lr.SetPosition(0, GunTip.position);
    lr.SetPosition(1, GrapplePoint);

  }

  void stopGrapple()
  {
    lr.positionCount = 0;
    Destroy(joint);
  }

}
