using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int CurrentLevel { get; private set; }
    public Vector2 PlayerPosition { get; private set; }
    public int PlayerHealth { get; private set; } //maybe float
    public int PlayerLives { get; private set; }
    private Dictionary <string, int> EnemiesDefeated;
    private Dictionary <string, int> CollectablesCollected;
    private int totalScore;
    public GameObject scorecardPanel; // Assign this in the Unity Editor
    public GameObject pauseMenuPanel; // Assign in Unity Editor
    public TextMeshProUGUI scoreText; // Assign this in the Unity Editor
    public TextMeshProUGUI gameOverText;
    public GameObject playerPrefab; // Assign in Unity Editor
    public GameObject gameOverPanel; // Assign in Unity Editor
    private GameObject currentPlayer;
    private EnemyFactory enemyFactory;
    public static LevelManager Instance { get; private set; }  // Singleton pattern implementation
    public Transform startPosition;

    void Start() 
   {
        CurrentLevel = 1;
        SpawnPlayer();
        pauseMenuPanel.SetActive(false);
        scorecardPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        //scorecardPanel.SetActive(false);
        //gameOverPanel.SetActive(false);
        PlayerPosition = new Vector2(0, 0);  //player.getPos() or player.setPos()
        PlayerHealth = 100;  //player.getHealth() or player.setHealth()
        PlayerLives = 3;     //player.getLives() or player.setLives()
        EnemiesDefeated = new Dictionary<string, int>();
        enemyFactory = FindObjectOfType<EnemyFactory>();
      
   }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Initialize current level, if needed
        CurrentLevel = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void EnemyDefeated(string enemyType) {
        if (!EnemiesDefeated.ContainsKey(enemyType)) {
            EnemiesDefeated.Add(enemyType, 1);
        } else {
            EnemiesDefeated[enemyType]++;
        }
    }

    public void CollectableCollected(string collectableType) {
        if (!CollectablesCollected.ContainsKey(collectableType)) {
            CollectablesCollected.Add(collectableType, 1);
        } else {
            CollectablesCollected[collectableType]++;
        }
    }

    // Method to be called when player reaches the end of the level
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndLevel();
        }
    }

    public void AdvanceToNextLevel()
    {
        CurrentLevel++;
        LoadLevel(CurrentLevel);
    }

    public void LoadLevel(int level)
    {
        // Logic to load the specified level scene
        // Example: SceneManager.LoadScene("Level" + level);
    }

    public void EndLevel()
    {
        // Logic to end the level
        // Call the scoring method here
        CalculateScore();
        AdvanceToNextLevel();
    }

    private void CalculateScore()
    {
        // Implement scoring logic here
        // Example: int score = (PlayerHealth * 10) + (CurrentLevel * 50) - (TimeTaken * 5);
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
        int score =  healthScore + collectableScore + enemyScore + levelScore;
        totalScore += score;

        //Display the score to the player
        scoreText.text = 
            "\nPlayer Health: \t\t\t\t" + healthScore +
            "\nCollectables Found: \t\t\t" + collectableScore +
            "\nEnemies Defeated: \t\t\t" + enemyScore +
            "\nLevel Bonus: \t\t\t\t" + levelScore +
            "\n\nLevel Score: \t\t\t\t" + score +
            "\n\nTotal Score: \t\t\t\t\t" + totalScore;
        scorecardPanel.SetActive(true);
    }

    public void ResetLevel() {
        CurrentLevel = 1;
        PlayerPosition = new Vector2(0, 0);
        PlayerHealth = 100;
        PlayerLives = 3;
        EnemiesDefeated = new Dictionary<string, int>();
    }

    public void SaveGame() {
        //PlayerHealth = playerPrefab.getHealth();
        //PlayerLives = playerPrefab.getLives();
        //PlayerPosition = playerPrefab.getPos();
        //save all the data to a file
    }

    public void LoadGame() {
        //playerPrefab.setHealth();
        //playerPrefab.setLives();
        //playerPrefab.setPos();
        //load all the data from a file
    }

    public void QuitGame() {
        //quit the game
    }

    public void TogglePause() {
        if (Time.timeScale == 0f)
        {
            // Resume game
            Time.timeScale = 1f;
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            // Pause game
            Time.timeScale = 0f;
            pauseMenuPanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void SpawnPlayer()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab is not assigned in LevelManager.");
            return;
        }
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(playerPrefab, startPosition.position, Quaternion.identity);
            // Set additional player properties if needed
        }
    }

    public void KillPlayer()
    {
        Destroy(currentPlayer);
        currentPlayer = null;
    }

    public void RespawnPlayer()
    {
        if (PlayerLives > 0)
        {
            // Optionally add delay or respawn animation
            currentPlayer.transform.position = startPosition.position;
            UpdatePlayerLives(-1);
            // Reset player state as needed
        }
        else
        {
            // Handle game over scenario
            CalculateScore();
            gameOverText.text = "Final Score" + totalScore;
            gameOverPanel.SetActive(true);
            // Optionally add delay or game over animation
        }
    }

    public void SpawnEnemy(string type, Vector3 position)
    {
        GameObject enemy = enemyFactory.CreateEnemy(type);
        if (enemy != null)
        {
            enemy.transform.position = position;
            // Initialize enemy-specific properties if needed
        }
    }

    public void UpdatePlayerLives(int numLives)
    {
        PlayerLives += numLives;
    }
}