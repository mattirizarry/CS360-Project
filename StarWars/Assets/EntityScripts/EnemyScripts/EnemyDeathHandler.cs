using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    public EntityHealthHandler healthHandler;

    private void Update()
    {
        if (healthHandler.GetHealth() <= 0) {
            Destroy(this.gameObject);
        }
    }
}
