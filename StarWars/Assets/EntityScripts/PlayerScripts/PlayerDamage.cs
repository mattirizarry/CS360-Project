using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Rigidbody2D rb;

    public float power = 1000f;

    public bool invuln;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamage") {
            OnHit();
        }
    }

    void OnHit() {
        rb.AddForce(Vector2.left * power * 4f);
        rb.AddForce(Vector2.up * power * 1.25f);
    }

    //IEnumerator FLicker() { 
    //
    //}
}
