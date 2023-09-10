using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image staminaFillImage; // Reference to the stamina bar's fill image
    public float maxStamina = 100f; // Maximum stamina value
    public float staminaDepletionRate = 5f; // Rate at which stamina depletes per second
    public bool isStaminaDepleting = false; // Boolean to control stamina depletion

    private float currentStamina;

    private void Start()
    {
        // Initialize the current stamina to the maximum value
        currentStamina = maxStamina;

        // Set the initial value of the stamina bar
        UpdateStaminaBar();
    }

    private void Update()
    {
        // Check if stamina should be depleting
        if (isStaminaDepleting)
        {
            DepleteStamina();
        }
    }

    private void DepleteStamina()
    {
        // Deplete stamina over time
        if (currentStamina > 0f)
        {
            currentStamina -= staminaDepletionRate * Time.deltaTime;

            // Ensure stamina doesn't go below zero
            if (currentStamina < 0f)
            {
                currentStamina = 0f;
            }

            // Update the stamina bar UI
            UpdateStaminaBar();
        }
    }

    private void UpdateStaminaBar()
    {
        // Update the fill amount of the stamina bar's Image component
        if (staminaFillImage != null)
        {
            staminaFillImage.fillAmount = currentStamina / maxStamina;
        }

    }
}
