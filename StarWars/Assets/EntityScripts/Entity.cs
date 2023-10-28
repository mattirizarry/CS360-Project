using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Object
{
    public int _health;



    public void Despawn(GameObject self) {

        Destroy(self);
    }
}
