using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenEvents : MonoBehaviour
{
    public GameObject stats;
    public GameObject buttons;
    public void ShowStats()
    {
        stats.SetActive(true);
    }

    public void ShowButtons()
    {
        buttons.SetActive(true);
    }
}
