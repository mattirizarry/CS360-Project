using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterUpgradeCollectable : MonoBehaviour
{
    public int fireRate = 10;
    public bool isCollected = false;

    public float GetFireRate() {
        return fireRate;
    }
}
