using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Player player;

    public Image healthBarState;
    public Sprite[] healthBarSprites;

    public Image healthBarFlash;
    public Sprite[] healthBarFlashSprites;

    private int previousHealth = -1;


    void Update()
    {
        int currentHealth = (int)player.health;
        healthBarState.sprite = healthBarSprites[currentHealth];

        // If health dropped, flash the overlay
        if (currentHealth < previousHealth)
        {
            
            if (currentHealth >= 1 && currentHealth <= 3)
            {
                int flashIndex = 3 - currentHealth;
                Debug.Log("FLASH INDEX: " + flashIndex);
                healthBarFlash.sprite = healthBarFlashSprites[flashIndex];
                StartCoroutine(FlashEffect());
            }
        }

        previousHealth = currentHealth;

    }

    IEnumerator FlashEffect()
    {
        Debug.Log("FlashEffect started");
        // Start fully visible
        Color flashColor = healthBarFlash.color;
        flashColor.a = 1f;
        healthBarFlash.color = flashColor;

        float duration = 0.3f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / duration);
            flashColor.a = alpha;
            healthBarFlash.color = flashColor;
            yield return null;
        }

        // Ensure it's fully invisible
        flashColor.a = 0f;
        healthBarFlash.color = flashColor;
    }
}