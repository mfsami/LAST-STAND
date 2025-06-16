using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class IntroLightFade : MonoBehaviour
{

    public Light2D globalLight;
    public Light2D campfireLight;
    public Light2D playerLight;
    public Light2D cigaretteLight;

    public float fadeDuration = 2f;

    public GameObject enemySpawner;

    public Player player;

    [Header("UI Animators")]
    public Animator healthBarAnimator;
    public Animator weaponUIAnimator;

    public GunController weapon;


    private void Start()
    {
        // Player cant move
        player.enabled = false;
        weapon.enabled = false;

        // Start all lights at 0
        globalLight.intensity = 0;
        campfireLight.intensity = 0;
        playerLight.intensity = 0;
        cigaretteLight.intensity = 0;

        // Begin the light sequence
        StartCoroutine(FadeInSequence());
    }

    IEnumerator FadeInSequence()
    {
        // Step 1: Campfire warms up
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeLight(campfireLight, 0, 2.33f, 5f)); // slow burn
        yield return new WaitForSeconds(0.5f);

        // Step 2: Global + player + cigarette light
        StartCoroutine(FadeLight(globalLight, 0, 0.14f, fadeDuration));
        StartCoroutine(FadeLight(playerLight, 0, 0.54f, fadeDuration));
        StartCoroutine(FadeLight(cigaretteLight, 0, 7.57f, fadeDuration));

        yield return new WaitForSeconds(fadeDuration + 0.5f);

        // Player can move
        player.enabled = true;
        weapon.enabled = true;

        healthBarAnimator.SetTrigger("SlideIn");
        weaponUIAnimator.SetTrigger("SlideIn");

        // Delay before spawning enemies
        yield return new WaitForSeconds(5f); 

        // Start spawning enemies
        enemySpawner.SetActive(true);
        Debug.Log("Game starts");
    }

    IEnumerator FadeLight(Light2D light, float from, float to, float duration)
    {
        float elapsed = 0;
        light.intensity = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            light.intensity = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        light.intensity = to;
    }
}
