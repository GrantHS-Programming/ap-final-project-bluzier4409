using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScopeScript : MonoBehaviour
{
    public Camera MainC;
    public Camera C;

    void Awake()
    {
        C.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            C.enabled= true;
            MainC.enabled = false;
        } else 
        {
            C.enabled= false;
            MainC.enabled = true;
        }
    }
}
