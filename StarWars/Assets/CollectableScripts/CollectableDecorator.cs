using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class CollectableDecorator : MonoBehaviour
{
    //all can be changed to Player class when that gets implemented
    public abstract void Collect(Entity player);
    /* Needs to be added to player/entity class
    void OnTriggerEnter2D(Collider2D other)
    {
        CollectableDecorator collectable = other.GetComponent<CollectableDecorator>();
        if (collectable != null)
        {
            collectable.Collect(this);
            Destroy(other.gameObject);
        }
    }
    */
}
