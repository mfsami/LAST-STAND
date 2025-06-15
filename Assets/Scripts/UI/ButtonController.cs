using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject fade;

    public void OnPlayPressed()
    {
        Debug.Log("Play pressed");
        fade.SetActive(true);
    }

    public void OnControlsPressed()
    {
        Debug.Log("Controls pressed");
    }

    public void OnExitPressed()
    {
        Debug.Log("Exit pressed");
    }
}
