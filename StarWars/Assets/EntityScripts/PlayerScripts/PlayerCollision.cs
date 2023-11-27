using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public SpriteRenderer spriterender;

    public Rigidbody2D rb;

    public float power = 1000f;

    public bool invuln;

    public PlayerShoot shoothandler; 

    public EntityHealthHandler healthHandler;

    public PlayerDeathHandler deathhandler;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamage" || collision.gameObject.tag == "Trap") {
            var dmgInst = collision.gameObject.GetComponent<EntityDamage>();
            
                OnHit(dmgInst.GetEntityDamage());
            
            
        }

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            if (collision.gameObject.GetComponent<HealthCollectable>()) {
                var healInst = collision.gameObject.GetComponent<HealthCollectable>();
                healthHandler.SetHealth(healthHandler.GetHealth() + healInst.GetHealAmount());
            }

            if (collision.gameObject.GetComponent<ExtraLifeCollectable>())
            {
                var lifeInst = collision.gameObject.GetComponent<ExtraLifeCollectable>();
                deathhandler.SetLife(deathhandler.GetLife() + lifeInst.GetLifeAmount());
            }

            if (collision.gameObject.GetComponent<BlasterUpgradeCollectable>())
            {
                var ratelifeInst = collision.gameObject.GetComponent<BlasterUpgradeCollectable>();
                shoothandler.SetRate(shoothandler.GetRate() - ratelifeInst.GetFireRate());
            }

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemyDamage")
        {
            var dmgInst = collision.gameObject.GetComponent<EntityDamage>();

            OnHit(dmgInst.GetEntityDamage());


        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Trap")
        {
            var dmgInst = collision.gameObject.GetComponent<EntityDamage>();

            OnHit(dmgInst.GetEntityDamage());


        }
    }

    void OnHit(int dmg) {
        if (!invuln) {
            healthHandler.SetHealth(healthHandler.GetHealth() - dmg);
            rb.AddForce(Vector2.left * power * 2f);
            rb.AddForce(Vector2.up * power * .25f);
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker() {
        if ( healthHandler.GetHealth() > 0) {
            spriterender.enabled = true;
            invuln = true;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = false;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = true;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = false;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = true;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = false;
            yield return new WaitForSeconds(.15f);
            spriterender.enabled = true;
            invuln = false;
        }
    }
}
