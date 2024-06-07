using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class Grenatki : MonoBehaviour
{
   public GameObject prefab;
   public GameObject c;
   public Rigidbody player;

   Rigidbody rb;

   void Update()
   {
       if (Input.GetMouseButtonDown(1))
       {
            GameObject bomba = Instantiate(prefab, c.transform.position, Quaternion.identity);
            rb = bomba.GetComponent<Rigidbody>();
            rb.velocity = player.velocity;
            rb.AddForce(c.transform.forward * 10, ForceMode.Impulse);
       }
   }
}
