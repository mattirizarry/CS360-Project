using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUIHandler : MonoBehaviour
{
    public EntityHealthHandler healthhandler;

    public PlayerDeathHandler deathhandler;

    public Slider healthslider;

    public Text lifecounter;  
    private void Start()
    {
        healthslider.maxValue = healthhandler.GetHealth();
    }

    private void Update()
    {
        lifecounter.text = deathhandler.GetLife().ToString();
        healthslider.value = healthhandler.GetHealth();
    }
}
