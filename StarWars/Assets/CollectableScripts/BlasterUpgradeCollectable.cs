using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterUpgradeCollectable : MonoBehaviour
{
    public float cooldownDecrease = .2f;

    public float GetFireRate() {
        return cooldownDecrease;
    }
}
