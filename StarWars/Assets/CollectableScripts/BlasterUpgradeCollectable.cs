using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterUpgradeCollectable : CollectableDecorator
{
    public int fireRate = 10;
    public override void Collect(Entity player)
    {

        //player.IncreaseFireRate(fireRate);
    }
}
