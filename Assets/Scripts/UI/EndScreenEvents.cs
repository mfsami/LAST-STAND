using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenEvents : MonoBehaviour
{
    public GameObject stats;
    public void ShowStats()
    {
        stats.SetActive(true);
    }
}
