using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : CollectableDecorator
{
    public int healthAmount = 30;

    public override void Collect(Entity player)
    {
        //player.IncreaseHealth(healthAmount);
    }
}


public class SmallHealthCollectable : CollectableDecorator
{
    public int healthAmount = 10;

    public override void Collect(Entity player)
    {
        //player.IncreaseHealth(healthAmount);
    }
}
