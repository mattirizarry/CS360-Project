using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float fixedYPosition = 0f; // Set this value in the Inspector to the desired Y-axis position

    // Update is called once per frame
    void Update()
    {
        // Camera follows the player on the X-axis and stays at the fixed Y position
        Vector3 newPos = new Vector3(target.position.x, fixedYPosition, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}



