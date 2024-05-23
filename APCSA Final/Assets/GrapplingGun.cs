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

  public float maxDist = 50f;

  private SpringJoint joint;

  public Transform GunTip, CameraHolder, Player;

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
    Physics.Raycast(CameraHolder.position, CameraHolder.forward, out hit, maxDist, grappleable);

    GrapplePoint = hit.point;
    joint = Player.gameObject.AddComponent<SpringJoint>();
    joint.autoConfigureConnectedAnchor = false;
    joint.connectedAnchor = GrapplePoint;

    float distanceFromPoint = Vector3.Distance(Player.position, GrapplePoint);

    //Distance to keep player in

    joint.maxDistance = distanceFromPoint * 0.8f;
    joint.minDistance = distanceFromPoint * 0.6f;

    // Spring Variables
    joint.spring = 6f;
    joint.damper = 3f;
    joint.massScale = 5f;

    lr.positionCount = 2;
  }

  void draw()
  {
    if (!joint) return;
    lr.SetPosition(0, GunTip.position);
    lr.SetPosition(1, GrapplePoint);

  }

  void stopGrapple()
  {
    lr.positionCount = 0;
    Destroy(joint);
  }

}
