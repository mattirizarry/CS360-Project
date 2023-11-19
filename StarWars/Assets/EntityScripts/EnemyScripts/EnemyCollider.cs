using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    public EntityHealthHandler healthHandler;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerDamage")
        {
            Debug.Log("Detected Player Damage");
            var dmgInst = collision.gameObject.GetComponent<EntityDamage>();

            OnHit(dmgInst.GetEntityDamage());


        }


    }
    void OnHit(int dmg)
    {
        healthHandler.SetHealth(healthHandler.GetHealth() - dmg);
        

    }

}
    
