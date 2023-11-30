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

    public Rigidbody2D rigidbody;

    private void Start()
    {
        
    }

    void Update()
    {

        rigidbody.freezeRotation = true;


        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        
        

        if (Input.GetKeyDown(KeyCode.Space) && !crouch) {
            
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !crouch)
        {
            Debug.Log("crouch");
            crouch = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
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

    public void setSpeed(int val) {
        speed = val;
    }
    
}
