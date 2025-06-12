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

    
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
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
}
