using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Player player;
    public Image healthBarState;
    public Sprite[] healthBarSprites;


    void Update()
    {
        int healthAmount = (int)player.health;

        
        healthBarState.sprite = healthBarSprites[healthAmount];

    }
}
