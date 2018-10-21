using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float cameraPitchLimitDown = 90f, cameraPitchLimitUp = -85f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Vector3 vector3;

    public Transform body;
    public Transform head;

    private void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (pitch > cameraPitchLimitDown)
        {
            pitch = cameraPitchLimitDown;
        }
        if (pitch < cameraPitchLimitUp)
        {
            pitch = cameraPitchLimitUp;
        }


        head.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void FixedUpdate()
    {        
        body.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

    }
}
