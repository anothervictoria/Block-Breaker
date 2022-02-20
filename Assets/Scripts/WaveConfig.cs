using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPath;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int quantityOfEnemies = 5;
    [SerializeField] float timeBetweenSpawns = 0.2f;
    [SerializeField] float spawnRandomFactor = 0.3f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints() 
    {
        List<Transform> waveWayPoints = new List<Transform>();
        foreach (Transform child in enemyPath.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints; 
    }
    public float GetMoveSpeed() { return moveSpeed; }
    public int GetQuantityOfEnemies() { return quantityOfEnemies; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }


}
