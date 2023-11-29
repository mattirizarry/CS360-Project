using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public CharacterController controller;

    public PlayerMovement moveScript;

    public AnimationClip walkClip;
    public AnimationClip idleClip;
    public AnimationClip jumpClip;
    public AnimationClip crouchClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && controller.getGrounded() && !moveScript.crouch)
        {
            animator.Play(walkClip.name);
        }

        if (!controller.getGrounded() && !moveScript.crouch) {
            animator.Play(jumpClip.name);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && controller.getGrounded() && !moveScript.crouch) {
            animator.Play(idleClip.name);
        }

        if (moveScript.crouch) {
            animator.Play(crouchClip.name);
        }
    }
}
