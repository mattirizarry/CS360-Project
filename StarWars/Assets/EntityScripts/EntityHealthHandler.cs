using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthHandler : MonoBehaviour
{
   
    public int _health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHealth() { 
        return _health;
    }

    public void SetHealth(int val)
    {
        _health = val;
    }
}
