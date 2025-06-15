using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject fade;
    public string loadGameScene;
    public string loadMenuScene;

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
        Application.Quit();
    }

    public void OnRetryPressed()
    {
        Debug.Log("Retry pressed");
        SceneManager.LoadScene(loadGameScene);
    }

    public void OnQuitPressed()
    {
        Debug.Log("Quit pressed");
        SceneManager.LoadScene(loadMenuScene);
    }

    
}
