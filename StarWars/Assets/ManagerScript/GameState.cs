using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class CollectableInfo
{

    public int collectibleID;
    public GameObject collectablePrefab; 
    public Vector3 position;      
    public bool isCollected;

    // Constructor
    public CollectableInfo(int id, GameObject prefab = null, Vector3 pos = default(Vector3), bool collected = false)
    {
        collectibleID = id;
        collectablePrefab = prefab;
        position = pos;
        isCollected = collected;
    }
}
public class EnemyInfo
{
    int enemyId;
    public bool isDefeated = false;
    public GameObject enemyPrefab; 
    public Vector3 position;       

    public EnemyInfo(int id, GameObject prefab = null, Vector3 pos = default(Vector3), bool defeated = false)
    {
        enemyId = id;
        enemyPrefab = prefab;
        position = pos;
        isDefeated = defeated;
    }

}

public class Scores {
    public int healthScore;
    public int collectableScore;
    public int enemyScore;
    public int levelScore;
    public int totalScore;

    public Scores(int health, int collectable, int enemy, int total) {
        healthScore = health;
        collectableScore = collectable;
        enemyScore = enemy;
        totalScore = total;
    }

    public override string ToString() {
        return "\nPlayer Health: \t\t\t\t" + healthScore +
                "\nCollectables Found: \t\t\t" + collectableScore +
                "\nEnemies Defeated: \t\t\t" + enemyScore +
                "\n\nLevel Score: \t\t\t\t" + totalScore;
    }
}


public class GameState
{
    public int CurrentLevel { get; set; }
    public int PlayerHealth { get; set; }
    public int PlayerLives { get; set; }
    public Transform PlayerPosition { get; set; }
    private int EnemiesDefeated;
    private int CollectablesCollected;

    public Scores CalculateScores()
    {
        PlayerHealth = GameManager.Instance.playerPrefab.GetComponent<EntityHealthHandler>().GetHealth();

        Debug.Log("Player Health: " + PlayerHealth);

        int collectableScore = 10 * CollectablesCollected;
        int enemyScore = 50 * EnemiesDefeated;
        int healthScore;

        if (PlayerHealth < 0) {
            healthScore = 0;
        } else {
            healthScore = PlayerHealth * 10;
        }

        int score = healthScore + collectableScore + enemyScore;

        return new Scores(healthScore, collectableScore, enemyScore, score);
    }

 

    public void UpdatePlayerLives(int numLives)
    {
        PlayerLives += numLives;
    }

    public void EnemyDefeated()
    {
        //struggling to figure out where this needs to be called from, probably enemy class when it dies
        //not sure how, maybe like below
        //GameManager.Instance.gameData.EnemyDefeated();
        EnemiesDefeated++;
        //enemy.isDefeated = true;
    }

    public void CollectableCollected()
    {
        //struggling to figure out where this needs to be called from, probably on collision class
        //not sure how, maybe like below
        //GameManager.Instance.gameData.CollectableCollected();
        CollectablesCollected++;
        //item.isCollected = true;

    }
}
