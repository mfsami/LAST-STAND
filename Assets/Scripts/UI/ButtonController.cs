using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    

    public void OnPlayPressed()
    {
        Debug.Log("Play pressed");
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
