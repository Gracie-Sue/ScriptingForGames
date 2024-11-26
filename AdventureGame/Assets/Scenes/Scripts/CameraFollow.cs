using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smooth movement speed
    public Vector3 offset; // Offset for camera position

    void LateUpdate()
    {
        if (target != null)
        {
            // Get the current camera position
            Vector3 desiredPosition = target.position + offset;

            // Lock the Y position to prevent vertical movement
            desiredPosition.y = transform.position.y;

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
