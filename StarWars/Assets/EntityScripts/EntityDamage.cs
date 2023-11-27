using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDamage : MonoBehaviour
{
    [SerializeField]
    int _damage;

    
    public int GetEntityDamage() { 
        return _damage;
    }

    
}
