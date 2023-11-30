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

    public GameObject bulletprefab;

    public GameObject gunPosition;

    public AudioSource blastersound;
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

            if(shooting == false)
            {
                 if(goingRight == true)
                {
                    StartCoroutine(shootAnim(false));
                }
                else
                {
                    StartCoroutine(shootAnim(true));
                }
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

    private IEnumerator shootAnim(bool status)
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

    //method called in animation events and spawns bullet
    public void shoot()
    {
        blastersound.Play();
        if (transform.localScale.x < 0) {
            var clone = Instantiate(bulletprefab, gunPosition.transform.position, transform.rotation);
            clone.GetComponent<BulletScript>().isRight = false;
        }

        if (transform.localScale.x > 0)
        {
            var clone = Instantiate(bulletprefab, gunPosition.transform.position, transform.rotation);
            clone.GetComponent<BulletScript>().isRight = true;
        }

    }

}
