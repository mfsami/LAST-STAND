using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsScreen : MonoBehaviour
{
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI coinsCollectedText;

    public PlayerData playerData;
    public EnemySpawner spawner;

    private float survivalTime;

    void Update()
    {
        survivalTime += Time.deltaTime;

        // Update UI
        timeSurvivedText.text = FormatTime(playerData.survivalTime);
        enemiesKilledText.text = spawner.TotalEnemiesKilled.ToString("D2");
        coinsCollectedText.text = playerData.totalCoinsCollected.ToString();
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:D2}:{seconds:D2}";
    }
}
