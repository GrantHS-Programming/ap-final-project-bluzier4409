using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed = 20f;
    private Vector2 motion;
    private Rigidbody rb;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        mouseMove();
    }

    void mouseMove()
    {
        motion.x += 2f * Input.GetAxis("Mouse X");
        motion.y += 2f * Input.GetAxis("Mouse Y");
        motion.y = Mathf.Clamp(motion.y, -90f, 90f);
        var hQuat= Quaternion.AngleAxis(motion.x, Vector3.up);
        var vQuat= Quaternion.AngleAxis(motion.y, Vector3.left);

        transform.localRotation = hQuat * vQuat;
    }
}
