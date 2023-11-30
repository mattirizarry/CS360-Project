using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeCollectable : MonoBehaviour
{
    public int numLives;

    public int GetLifeAmount(){ 
        return numLives;
    }
}
