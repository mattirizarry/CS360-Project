using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController contoller;

    public float speed;

    public float horizontal;

    public bool jump;

    public bool crouch;
    
    void Update()
    {



        
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        
        

        if (Input.GetKeyDown(KeyCode.Z)) {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        contoller.Move(horizontal * Time.fixedDeltaTime,crouch, jump);
        jump = false;
    }
}
