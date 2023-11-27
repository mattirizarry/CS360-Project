// EnemyFactory.cs
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyType1Prefab;
    public GameObject enemyType2Prefab;
    

    public GameObject CreateEnemy(string type)
    {
        switch (type)
        {
            case "EnemyType1":
                return Instantiate(enemyType1Prefab);
            case "EnemyType2":
                return Instantiate(enemyType2Prefab);
            default:
                return null;
        }
    }
}