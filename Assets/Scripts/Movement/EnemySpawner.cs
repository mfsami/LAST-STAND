using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject enemyPrefab;

    public float spawnInterval = 5f;
    public float spawnDistanceFromPlayer = 12f;

    private float spawnTimer = 0f;

    // Delays 
    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 8f;

    public int minEnemiesPerSpawn = 1;
    public int maxEnemiesPerSpawn = 3;

    private float currentSpawnDelay;

    private void Start()
    {
        SetRandomSpawnDelay();
    }


    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnDelay)
        {

            spawnTimer = 0f;

            int enemiesToSpawn = Random.Range(minEnemiesPerSpawn, maxEnemiesPerSpawn + 1);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
            }

            SetRandomSpawnDelay();

        }
    }

    void SpawnEnemy()
    {
        // Exit early if player is destroyed
        if (playerTransform == null)
            return;

        // Pick random direction around the player
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomDir.x, randomDir.y, 0) * spawnDistanceFromPlayer;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    }

    void SetRandomSpawnDelay()
    {
        currentSpawnDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
