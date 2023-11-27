using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterUpgradeCollectable : MonoBehaviour
{
    public int fireRate = 10;
    public bool isCollected = false;
    public void Collect(Entity player)
    {
        isCollected = true;
        GameManager.Instance.gameData.CollectableCollected();
        //player.IncreaseFireRate(fireRate);
    }
    public float GetFireRate() {
        return fireRate;
    }
}
