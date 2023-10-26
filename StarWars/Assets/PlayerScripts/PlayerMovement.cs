using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController contoller;

    public float speed;

    public float horizontal;

    public bool jump;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKey(KeyCode.Space)) {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        contoller.Move(horizontal * Time.fixedDeltaTime,false, jump);
        jump = false;
    }
}
