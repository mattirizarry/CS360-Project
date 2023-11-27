using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterUpgradeCollectable : CollectableDecorator
{
    public int fireRate = 10;
    public bool isCollected = false;
    public override void Collect(Entity player)
    {
        isCollected = true;
        GameManager.Instance.gameData.CollectableCollected();
        //player.IncreaseFireRate(fireRate);
    }
}
