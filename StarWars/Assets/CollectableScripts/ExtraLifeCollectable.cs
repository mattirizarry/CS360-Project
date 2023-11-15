using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeCollectable : CollectableDecorator
{
    public int numLives = 1;

    public override void Collect(Entity player)
    {
        //player.IncreaseNumLives(numLives);
    }
}
