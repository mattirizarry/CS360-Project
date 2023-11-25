using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.Instance == null)
            {
                Debug.LogError("LevelEndTrigger: GameManager instance is null.");
                return;
            }

            Debug.Log("LevelEndTrigger: Player has triggered the end level.");
            GameManager.Instance.EndLevel();
        }
    }

}

