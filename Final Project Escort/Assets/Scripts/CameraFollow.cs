using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObj;
    public Vector3 cameraOffset;
    public float smoothFollow = 0.5f;
    public bool lookAtTarget = false;
    void Start()
    {
        cameraOffset = transform.position - targetObj.transform.position;
    }

    
    void LateUpdate()
    {
        Vector3 newPosition = targetObj.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFollow);

        if (lookAtTarget)
        {
            transform.LookAt(targetObj);
        }
    }
}
