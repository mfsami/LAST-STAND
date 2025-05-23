using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int money = 0;
    
    public void AddCoin(int amount)
    {
        money += amount;
        Debug.Log("Obtained: " + amount);
        Debug.Log("New balance: " + money);
    }
}
