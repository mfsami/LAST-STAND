using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    public GameObject deathScreen;

    public AudioSource bellSource;
    public AudioSource choirSource;
    public AudioSource ambientSource;

    public AudioClip bell;
    public AudioClip choir;
    public AudioClip ambient;

    public void ShowYouDied()
    {
        deathScreen.SetActive(true);

        bellSource.clip = bell;
        bellSource.Play();

        choirSource.clip = choir;
        choirSource.Play();

        ambientSource.clip = ambient;
        ambientSource.Play();
    }
}
