using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    public GameObject deathScreen; 
    
    public void ShowYouDied()
    {
        deathScreen.SetActive(true);
    }
}
