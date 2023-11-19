using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody2D rb;

    public float power = 1000f;

    public bool invuln;

    
    public EntityHealthHandler healthHandler;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamage") {
            var dmgInst = collision.gameObject.GetComponent<EntityDamage>();
            
                OnHit(dmgInst.GetEntityDamage());
            
            
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
           
            Destroy(collision.gameObject);
        }
    }

    void OnHit(int dmg) {
        healthHandler.SetHealth(healthHandler.GetHealth() - dmg);
        rb.AddForce(Vector2.left * power * 4f);
        rb.AddForce(Vector2.up * power * 1.25f);
    }

    //IEnumerator FLicker() { 
    //
    //}
}
