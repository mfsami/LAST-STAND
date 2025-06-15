using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int money = 0;
    public TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = money.ToString();
    }

    public void AddCoin(int amount)
    {
        money += amount;
        //Debug.Log("Obtained: " + amount);
        //Debug.Log("New balance: " + money);
    }
}
