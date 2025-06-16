using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject fade;
    public string loadGameScene;
    public string loadMenuScene;

    // Audio
    public AudioSource src;
    public AudioClip buttonPress;

    public void OnPlayPressed()
    {
        Debug.Log("Play pressed");
        fade.SetActive(true);

        ButtonSFX();
    }

    public void OnControlsPressed()
    {
        Debug.Log("Controls pressed");
        ButtonSFX();
    }

    public void OnExitPressed()
    {
        Debug.Log("Exit pressed");
        ButtonSFX();
        Application.Quit();

    }

    public void OnRetryPressed()
    {
        Debug.Log("Retry pressed");
        ButtonSFX();
        SceneManager.LoadScene(loadGameScene);
    }

    public void OnQuitPressed()
    {
        Debug.Log("Quit pressed");
        ButtonSFX();
        SceneManager.LoadScene(loadMenuScene);
    }

    private void ButtonSFX()
    {
        src.clip = buttonPress;
        src.Play();
    }

    
}
