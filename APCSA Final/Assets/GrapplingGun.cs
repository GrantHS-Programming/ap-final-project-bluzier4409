using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
  private LineRenderer lr;
  private Vector3 GrapplePoint;

  public LayerMask grappleable;

  void Awake()
  {
    lr = GetComponent<LineRenderer>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
       // Grapple();
    }
    else if (Input.GetMouseButtonUp(0))
    {
      //  StopGrapple();
    }
  }

}
