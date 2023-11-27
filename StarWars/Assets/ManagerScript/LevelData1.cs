using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelData : MonoBehaviour
{
    //public List<EnemyData> enemies;
    //public List<ConsumableData> consumables;
    // Start is called before the first frame update
    public List<CollectableInfo> items = new List<CollectableInfo>();
    public List<EnemyInfo> enemies = new List<EnemyInfo>();
    public Transform playerSpawnPoint;
    public Transform enemy1Pos;
    public Transform enemy2Pos;
    public Transform item1Pos; //smallHealthOrb
    public Transform item2Pos; //healthOrb
    public Transform item3Pos; //extraLife
    public Transform item4Pos; //blasterUpgrade
    //public GameObject stormCloackPreFab;
    //public GameObject otherEnemyPreFab;
    public GameObject smallHealthPreFab;
    public GameObject healthOrbFreFab;
    public GameObject extraLifePreFab;
    public GameObject blasterUpgradePreFab;


    private Dictionary<GameObject, Vector3> enemyPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Vector3> itemPositions = new Dictionary<GameObject, Vector3>();




    void Start()
    {
        CollectableInfo smallHealth = new CollectableInfo(1, smallHealthPreFab, item1Pos.position, false);
        CollectableInfo healthOrb = new CollectableInfo(2, healthOrbFreFab, item2Pos.position, false);
        CollectableInfo extraLife = new CollectableInfo(3, extraLifePreFab, item3Pos.position, false);
        CollectableInfo blasterUpgrade = new CollectableInfo(4, blasterUpgradePreFab, item4Pos.position, false);
        items.Add(smallHealth);
        items.Add(healthOrb);
        items.Add(extraLife);
        items.Add(blasterUpgrade);


        //EnemyInfo stormTrooper1 = new EnemyInfo(1, stormCloackPreFab, enemy1Pos.position, false);
        //EnemyInfo stormTrooper2 = new EnemyInfo(2, stormCloackPreFab, enemy2Pos.position, false);
        //enemies.Add(stormTrooper1);
        //enemies.Add(stormTrooper2);

        SetItemAndEnemyPositions();

    }

    void Awake()
    {
        SetItemAndEnemyPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetItemAndEnemyPositions()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.isDefeated)
                enemyPositions.Add(enemy.enemyPrefab, enemy.position);
        }

        foreach (var item in items)
        {
            if (!item.isCollected)
                itemPositions.Add(item.collectablePrefab, item.position);
        }
    }
    public Vector3 GetSpawnPosition()
    {
        return playerSpawnPoint.position;
    }

    public Dictionary<GameObject, Vector3> GetEnemyPositions()
    {
        return enemyPositions;
    }

    public Dictionary<GameObject, Vector3> GetItemPositions()
    {
        return itemPositions;
    }

    public Vector3 GetPlayerPostition()
    {
        //needs to be replaced by position getter Method for player! 
        //return player.getPos()
        return playerSpawnPoint.position;
    }
}
