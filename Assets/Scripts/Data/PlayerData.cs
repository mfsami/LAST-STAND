using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int money = 0;
    public TextMeshProUGUI coinText;

    [Header("Audio")]
    public AudioClip coinSound;
    public AudioSource coinSrc;

    void Update()
    {
        coinText.text = money.ToString();
    }

    public void AddCoin(int amount)
    {
        money += amount;
        coinSrc.clip = coinSound;
        coinSrc.Play();
        //Debug.Log("Obtained: " + amount);
        //Debug.Log("New balance: " + money);
    }
}
