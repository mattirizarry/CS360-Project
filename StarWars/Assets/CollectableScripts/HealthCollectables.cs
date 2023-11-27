using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public int healthAmount = 30;


    public int GetHealAmount() {
        return healthAmount;
    }
}


