using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script controls player movement
/// </summary>
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
        
        

        if (Input.GetKeyDown(KeyCode.Z) && !crouch) {
            
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !jump)
        {
            Debug.Log("crouch");
            crouch = true;
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Exit crouch");
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        contoller.Move(horizontal * Time.fixedDeltaTime,crouch, jump);
        jump = false;
    }
}
