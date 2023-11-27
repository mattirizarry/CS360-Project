using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
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
    public static GameManager Instance { get; private set; }  // Singleton pattern implementation
    public GameState gameData;
    public LevelEndMusic levelCompleteAudio;
    LevelData currentLevelData;
    public GameOverSound gameOverSound;
    public BackgroundMusic bgMusic;
    void Start() 
   {
        CurrentLevel = 1;
        StartLevel();
        pauseMenuPanel.SetActive(false);
        scorecardPanel.SetActive(false);
        gameOverPanel.SetActive(false);
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
            gameData = new GameState(); // Initialize gameData here
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void StartLevel()
    {
        currentLevelData = FindObjectOfType<LevelData>(); // Find the LevelData for the current level
        if (currentLevelData != null)
        {
            SpawnPlayer(currentLevelData.GetSpawnPosition());
            bgMusic.PlayMusic();
            //needs to be replanced by below method
            //SpawnPlayer(currentLevelData.GetPlayerPosition());
            SpawnEnemies(currentLevelData.GetEnemyPositions());
            SpawnItems(currentLevelData.GetItemPositions());

        }
    }

    void ResumeLevel()
    {
        LevelData currentLevelData = FindObjectOfType<LevelData>(); // Find the LevelData for the current level
        if (currentLevelData != null)
        {
            bgMusic.PlayMusic();
            SpawnPlayer(currentLevelData.GetSpawnPosition());
            //needs to be replanced by below method
            //SpawnPlayer(currentLevelData.GetPlayerPosition());
            SpawnEnemies(currentLevelData.GetEnemyPositions());
            SpawnItems(currentLevelData.GetItemPositions());

        }
    }

    void SpawnEnemies(Dictionary<GameObject, Vector3> enemyPositions)
    {
        //Dictonary has already been checked if defeated
        foreach (var entry in enemyPositions)
        {
            Instantiate(entry.Key, entry.Value, Quaternion.identity);
        }
    }

    void SpawnItems(Dictionary<GameObject, Vector3> itemPositions)
    {
        //Dictonary has already been checked if collected
        foreach (var item in itemPositions)
        {
            Instantiate(item.Key, item.Value, Quaternion.identity);
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
        //LoadLevel(CurrentLevel);
    }

    public void LoadLevel(int level)
    {
        // Logic to load the specified level scene
        // Example: SceneManager.LoadScene("Level" + level);
    }

    public void EndLevel()
    {
        // Debugging to check for null references
        if (gameData == null)
        {
            Debug.LogError("GameManager: GameData is null.");
            return;
        }
        if (scoreText == null)
        {
            Debug.LogError("GameManager: ScoreText is null.");
            return;
        }

        Debug.Log("GameManager: Ending Level...");
        bgMusic.StopMusic();
        levelCompleteAudio.Play();
        gameData.CalculateScore(scoreText);
        scorecardPanel.SetActive(true);
        //AdvanceToNextLevel();
    }


    public void ResetLevel() {
        CurrentLevel = 1;
        PlayerPosition = new Vector2(0, 0);
        PlayerHealth = 100;
        PlayerLives = 3;
        EnemiesDefeated = new Dictionary<string, int>();
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

    public void SpawnPlayer(Vector3 spawnPos)
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab is not assigned in LevelManager.");
            return;
        }
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            // Set additional player properties if needed
        }
    }

    public void KillPlayer()
    {
        Destroy(currentPlayer);
        currentPlayer = null;
    }

    public void RespawnPlayer(Vector3 spawnPos)
    {
        if (PlayerLives > 0)
        {
            // Optionally add delay or respawn animation
            currentPlayer.transform.position = spawnPos;
            gameData.UpdatePlayerLives(-1);
            // Reset player state as needed
        }
        else
        {
            // Handle game over scenario
            GameOver();
            
        }
    }

    public void GameOver()
    {
        // Optionally add delay or game over animation
        gameData.CalculateEndScore(gameOverText);
        gameOverPanel.SetActive(true);
        if (gameOverSound != null)
        {
            gameOverSound.PlayGameOverSound();
        }
        else
        {
            Debug.LogError("GameOverSound script is not assigned in GameManager.");
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


    public void SaveGame()
    {
        //update player health
        //gameData.PlayerHealth = playerPrefab.getHealth();

        //update player lives
        //gameData.PlayerLives = playerPrefab.getLives();

        //update player pos
        //gameData.PlayerPosition = playerPrefab.getPosition();
        
        //save player health,lives, pos
        //save collectable list
        

        //potential logic to save and load enemy and collectables 
        //could also track enemy health if desired, but probably unnecessary for our scope atm
        //foreach (EnemyInfo enemy in currentLevelData.enemies)
        //{
        //    if (enemy.enemyPrefab.getHealth() <= 0 || enemy.enemyPrefab.isDefeated())
        //    {
        //        enemy.isDefeated = true;
        //    }
        //}

        //foreach (CollectableInfo item in currentLevelData.items)
        //{
        //    if (item.collectablePrefab.isCollected())
        //    {
        //        item.isCollected() = true;
        //    }
        //}

        //save num items collected and num enemies defeated

        //save enemy list
        //save level #

        //saveGameData???

    }

    public void LoadGame()
    {
        //load player health,lives, pos
        //playerPrefab.setHelth();
        //playerPrefab.setPosition();
        //playerPrefab.setLives();
        

        //load collectable list
        //load enemy list
        //set player health, lives, pos
        //set collectable lsit
        //set enemy lsit
        //load level #

        //load enemy data

        //load item data



    }


   

}