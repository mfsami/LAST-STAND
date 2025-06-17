using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject enemyPrefab;


    public float spawnRadius = 12f;
    public float spawnInterval = 1.5f;
    public int startingEnemies = 10;
    public float roundDelay = 10f;

    private int currentRound = 1;
    private int enemiesToSpawn;
    private int enemiesSpawned = 0;
    private int enemiesAlive = 0;

    private float spawnTimer = 0f;
    private bool roundInProgress = false;
    public float spawnDistanceFromPlayer = 12f;

    public int enemyMultiplier = 5;

    public int TotalEnemiesKilled { get; private set; }

    private void Start()
    {
        StartNewRound();
    }


    void Update()
    {

        if (!roundInProgress) return;
        
        spawnTimer += Time.deltaTime;


        if (spawnTimer >= spawnInterval && enemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        // If rounds over
        if (enemiesSpawned == enemiesToSpawn && enemiesAlive <= 0)
        {
            roundInProgress = false;
            Debug.Log($"Round {currentRound} complete! Next round in {roundDelay} seconds...");
            StartCoroutine(NextRoundAfterDelay(roundDelay));
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

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        enemiesAlive++;
        enemiesSpawned++;

        enemy.GetComponent<Enemy>().OnDeath = () =>
        {
            enemiesAlive--;
            TotalEnemiesKilled++; // Track total kills
        };

    }

    IEnumerator NextRoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentRound++;
        StartNewRound();
    }

    void StartNewRound()
    {
        enemiesToSpawn = startingEnemies + (currentRound - 1) * enemyMultiplier; 
        enemiesSpawned = 0;
        enemiesAlive = 0;
        roundInProgress = true;

        Debug.Log($"--- Round {currentRound} Started ---");
    }
}
