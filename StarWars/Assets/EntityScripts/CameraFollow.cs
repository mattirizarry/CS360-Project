using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    // Boundary coordinates
    private float minX = -7f;
    private float maxX = 184f;
    private float minY = -5f;
    private float maxY = 24f;

    private Camera cam; // Camera reference

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(
            playerTransform.position.x + cameraOffset.x,
            transform.position.y, // Keep the y position constant
            transform.position.z);

        // Calculate the visible width based on the camera's viewport size
        float horzExtent = cam.orthographicSize * Screen.width / Screen.height;

        // Adjust min and max values based on the camera's viewport size
        float adjustedMinX = minX + horzExtent;
        float adjustedMaxX = maxX - horzExtent;

        // Clamping the camera's x position
        newPosition.x = Mathf.Clamp(newPosition.x, adjustedMinX, adjustedMaxX);

        transform.position = newPosition;
    }
}



