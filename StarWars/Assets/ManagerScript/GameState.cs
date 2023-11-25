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


public class GameState
{
    public int CurrentLevel { get; set; }
    public int PlayerHealth { get; set; }
    public int PlayerLives { get; set; }
    public Transform PlayerPosition { get; set; }
    private int totalScore = 0;
    private int EnemiesDefeated;
    private int CollectablesCollected;

    

    public void CalculateEndScore(TextMeshProUGUI scoreText)
    {
        // Implement scoring logic here
        totalScore += CalculateLevelScore(scoreText);
        scoreText.text = "\n\nTotal Score: \t\t\t\t\t" + totalScore;
    }


    public void CalculateScore(TextMeshProUGUI scoreText)
    {
        // Implement scoring logic here
        totalScore += CalculateLevelScore(scoreText);
        scoreText.text += "\n\nTotal Score: \t\t\t\t\t" + totalScore;
    }

    private int CalculateLevelScore(TextMeshProUGUI scoreText)
    {
        // Calculate the score for the current level
        // Implement scoring logic here
        // Display the score to the player
        //PlayerHealth = playerPrefab.getHealth();
        int collectableScore = 0;
        //foreach (KeyValuePair<string, int> collectable in CollectablesCollected) {
        //    collectableScore += collectable.Value * 10;
        //}
        int enemyScore = 0;
        //foreach (KeyValuePair<string, int> enemy in EnemiesDefeated) {
        //    enemyScore += enemy.Value * 50;
        //}
        int healthScore = PlayerHealth * 10;
        int levelScore = CurrentLevel * 50;
        int score = healthScore + collectableScore + enemyScore + levelScore;

        //Display the score to the player
        scoreText.text =
            "\nPlayer Health: \t\t\t\t" + healthScore +
            "\nCollectables Found: \t\t\t" + collectableScore +
            "\nEnemies Defeated: \t\t\t" + enemyScore +
            "\nLevel Bonus: \t\t\t\t" + levelScore +
            "\n\nLevel Score: \t\t\t\t" + score;

        return score;
    }

 

    public void UpdatePlayerLives(int numLives)
    {
        PlayerLives += numLives;
        //player.setLives(PlayerLives);
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
