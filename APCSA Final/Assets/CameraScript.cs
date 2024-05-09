using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 motion;
    private Rigidbody rb;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    // Update is called once per frame
    void Update()
    {
        mouseMove();
    }

    void mouseMove()
    {
        float h = 2f * Input.GetAxis("Mouse X");
        float v = 2f * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);
    }
}
