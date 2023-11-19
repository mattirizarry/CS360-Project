using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;

    public float movementTime;

    public float maxTime;

    public float horizontal;

    public bool goingRight;

    public bool shooting;

    public AnimationClip shootingAni;

    public AnimationClip walkingAni;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy to left or right
        if(shooting == false){

            anim.Play(walkingAni.name);

            if (goingRight)
            {
                transform.position += transform.right * Time.deltaTime * speed;
            }
            else {
                transform.position += -transform.right * Time.deltaTime * speed;
            }

            //tracks the time the enemy has been moving in a certain direction
            movementTime += Time.deltaTime;

        }
        
        // Will change the direction of where the enemy will move
        if(movementTime >= maxTime){


            if(goingRight == true)
            {
                StartCoroutine(shoot(false));
            }
            else
            {
                StartCoroutine(shoot(true));
            }
        }

    }

    private void Flip()
    {
        
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private IEnumerator shoot(bool status)
    {
        anim.Play(shootingAni.name);
        shooting = true;
        //shooting logic goes here

        yield return new WaitForSeconds(shootingAni.length);

        shooting = false;
        
        goingRight = status;
        movementTime = 0;
        Flip();
    }

}
