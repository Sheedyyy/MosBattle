using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 400; // Max health for the boss
   [SerializeField] private int currentHealth;
    public Camera mainCamera; // The main game camera
    public Camera deathCamera; // The secondary camera for the death sequence
    public float deathTransitionDelay = 15f; // Time to wait before switching scenes
    public float blackScreenDuration = 2f; // Duration of the black screen before switching scenes
    public Image healthBarImage; // The image to represent boss's health

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health

        if (deathCamera != null)
        {
            deathCamera.gameObject.SetActive(false); // Ensure death camera is not active at the start
        }
        else
        {
            Debug.LogError("Death camera is not assigned.");
        }

        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned.");
        }

        if (healthBarImage != null)
        {
            // Set the fill amount of the health bar image to reflect the initial health
            healthBarImage.fillAmount = 1f; // Full health at start
        }
        else
        {
            Debug.LogError("Health bar image is not assigned.");
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage value cannot be negative.");
            return;
        }

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Ensure health doesn't go below 0
            Die();
        }

        // Update the fill amount of the health bar image
        UpdateHealthBar();
    }

    private void Update()
    {
        // Always ensure the health bar is updated to reflect the current health
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = (float)currentHealth / maxHealth;
            Debug.Log($"Health bar updated: {healthBarImage.fillAmount * 100}%");
        }
    }

    private void Die()
    {
        // Handle boss death (e.g., play death animation, sound effects)
        Debug.Log("Boss has died.");

        // Switch to the death camera
        SwitchToDeathCamera();

        // Start the coroutine to handle the transition
        StartCoroutine(HandleDeathTransition());
    }

    private void SwitchToDeathCamera()
    {
        if (mainCamera != null)
        {
            Debug.Log("Disabling main camera.");
            mainCamera.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Main camera is null.");
        }

        if (deathCamera != null)
        {
            Debug.Log("Enabling death camera.");
            deathCamera.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Death camera is null.");
        }
    }

    private IEnumerator HandleDeathTransition()
    {
        // Wait for a specified time before switching scenes
        yield return new WaitForSeconds(deathTransitionDelay);

        // Start fade to black (if applicable) and wait for the duration
        yield return StartCoroutine(FadeToBlack());

        // Load the end game scene
        SceneManager.LoadScene("EndGame");
    }

    private IEnumerator FadeToBlack()
    {
        // Fade to black screen logic (e.g., activate a UI image that covers the screen)
        CanvasGroup blackScreen = FindObjectOfType<CanvasGroup>();
        if (blackScreen == null)
        {
            Debug.LogError("No CanvasGroup found for the black screen fade.");
            yield break;
        }

        blackScreen.alpha = 0;
        blackScreen.gameObject.SetActive(true);

        // Fade in
        float elapsedTime = 0f;
        while (elapsedTime < blackScreenDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.alpha = Mathf.Clamp01(elapsedTime / blackScreenDuration);
            yield return null;
        }

        blackScreen.alpha = 1; // Ensure fully opaque
    }
}